namespace ResFin.Infrastructure.Outbox;

public sealed class OutboxMessage
    {
        public OutboxMessage(
            Guid id, 
            DateTime occurredUtc, 
            string type, 
            string content
         )
        {
            Id = id;
            OccurredUtc = occurredUtc;
            Type = type;
            Content = content;
           
        }
        public Guid Id { get; init; }
    public DateTime OccurredUtc { get; init; }
    public string Type { get; init; }
    public string Content { get; init; }
    public DateTime ProcessedUtc { get; init; }
    public string? Error { get; init; }
    }