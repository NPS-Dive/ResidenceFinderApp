namespace ResFin.Domain.Users.Events;

public sealed record UserCreatedDomainEvent (
    Guid UserId
    )
    : IDomainEvent;