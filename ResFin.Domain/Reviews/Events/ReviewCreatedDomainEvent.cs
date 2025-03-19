namespace ResFin.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent (
    Guid ReviewId 
    )
    : IDomainEvent;