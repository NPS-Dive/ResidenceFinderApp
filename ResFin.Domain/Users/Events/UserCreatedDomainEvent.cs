namespace ResFin.Domain.Users.Events;

public record UserCreatedDomainEvent (
    Guid UserId
    )
    : IDomainEvent;