﻿namespace ResFin.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
    {
    private readonly IPublisher _publisher;

    public ApplicationDbContext ( DbContextOptions options, IPublisher? publisher = null )
    : base(options)
        {
        _publisher = publisher;
        }

    protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        }

    public override async Task<int> SaveChangesAsync ( CancellationToken cancellationToken = new CancellationToken() )
        {
            
            if (_publisher != null)
            {
                      try
            {
            var result = await base.SaveChangesAsync(cancellationToken);
            await PublishDomainEventsAsync();
            return result;
            }
        catch (DbUpdateConcurrencyException dbConException)
            {
            throw new ConcurrencyException("Concurrency Exception Occured!", dbConException);
            }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    private async Task PublishDomainEventsAsync ()
        {
        var domainEvents = ChangeTracker
            .Entries<BaseEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
            {
            await _publisher.Publish(domainEvent);
            }
        }
    }