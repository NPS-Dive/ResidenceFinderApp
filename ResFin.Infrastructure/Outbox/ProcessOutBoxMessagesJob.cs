﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;

namespace ResFin.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutBoxMessagesJob : IJob
    {
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
        TypeNameHandling = TypeNameHandling.All
        };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPublisher _publisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly OutBoxOptions _outBoxOptions;
    private readonly ILogger<ProcessOutBoxMessagesJob> _logger;

    public ProcessOutBoxMessagesJob (
        ISqlConnectionFactory sqlConnectionFactory,
        IPublisher publisher,
        IDateTimeProvider dateTimeProvider,
        IOptions<OutBoxOptions> outBoxOptions,
        ILogger<ProcessOutBoxMessagesJob> logger )
        {
        _sqlConnectionFactory = sqlConnectionFactory;
        _publisher = publisher;
        _dateTimeProvider = dateTimeProvider;
        _logger = logger;
        _outBoxOptions = outBoxOptions.Value;
        }

    public async Task Execute ( IJobExecutionContext context )
        {
        _logger.LogInformation("Beginning to process outbox messages");

        using var connection = _sqlConnectionFactory.CreateConnection();
        using var transaction = connection.BeginTransaction();

        var outboxMessages = await GetOutboxMessagesAsync(connection, transaction);

        foreach (var outboxMessage in outboxMessages)
            {
            Exception? exception = null;

            try
                {
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                    outboxMessage.Content,
                    JsonSerializerSettings)!;

                await _publisher.Publish(domainEvent, context.CancellationToken);
                }
            catch (Exception caughtException)
                {
                _logger.LogError(
                    caughtException,
                    "Exception while processing outbox message {MessageId}",
                    outboxMessage.Id);

                exception = caughtException;
                }

            await UpdateOutboxMessageAsync(connection, transaction, outboxMessage, exception);
            }

        transaction.Commit();

        _logger.LogInformation("Completed processing outbox messages");
        }

    private async Task<IReadOnlyList<OutboxMessageResponse>> GetOutboxMessagesAsync (
        IDbConnection connection,
        IDbTransaction transaction )
        {
        var sql = $"""                
            SELECT id, content
            FROM outbox_messages
            WHERE processed_on_utc IS NULL
            ORDER BY occurred_on_utc
            LIMIT {_outBoxOptions.BatchSize}
            FOR UPDATE
            """;

        var outboxMessages = await connection.QueryAsync<OutboxMessageResponse>(sql, transaction: transaction);

        return outboxMessages.ToList();
        }

    private async Task UpdateOutboxMessageAsync (
        IDbConnection connection,
        IDbTransaction transaction,
        OutboxMessageResponse outboxMessage,
        Exception? exception )
        {
        const string sql = @"
            UPDATE outbox_messages
            SET processed_on_utc = @ProcessedOnUtc,
                error = @Error
            WHERE id = @Id";

        await connection.ExecuteAsync(
            sql,
            new
                {
                outboxMessage.Id,
                ProcessedOnUtc = _dateTimeProvider.UtcNow,
                Error = exception?.ToString()
                },
            transaction: transaction);
        }

   
    }