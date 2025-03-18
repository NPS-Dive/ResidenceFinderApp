using Newtonsoft.Json;
using ResFin.Infrastructure.Outbox;

namespace ResFin.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
    {
    private static readonly JsonSerializerSettings jsonSerializerSettings = new()
        {
        TypeNameHandling = TypeNameHandling.All
        };
  
    private readonly IDateTimeProvider _dateTimeProvider;

    public ApplicationDbContext (
        DbContextOptions options,
        IDateTimeProvider dateTimeProvider )
    : base(options)
        {
        _dateTimeProvider = dateTimeProvider;

        }

  
    protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        }

    public override async Task<int> SaveChangesAsync ( CancellationToken cancellationToken = new CancellationToken() )
        {
        try
            {
            AddDomainEventsAsOutBoxMessages();

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
            }
        catch (DbUpdateConcurrencyException dbConException)
            {
            throw new ConcurrencyException("Concurrency Exception Occured!", dbConException);
            }


        return await base.SaveChangesAsync(cancellationToken);
        }

    private async Task AddDomainEventsAsOutBoxMessages ()
        {
        var outBoxMessage = ChangeTracker
            .Entries<BaseEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                Guid.NewGuid(),
               _dateTimeProvider.UtcNow,
                domainEvent.GetType().Name,
                JsonConvert.SerializeObject(domainEvent, jsonSerializerSettings)
                ))
            .ToList();

        AddRange(outBoxMessage);

       
        }
    }