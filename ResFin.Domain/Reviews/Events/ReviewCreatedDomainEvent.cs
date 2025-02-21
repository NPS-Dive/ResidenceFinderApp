namespace ResFin.Domain.Reviews.Events;

public record ReviewCreatedDomainEvent (
    Guid ReviewId 
    )
    : IDomainEvent;