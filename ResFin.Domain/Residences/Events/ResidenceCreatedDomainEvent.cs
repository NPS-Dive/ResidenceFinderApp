namespace ResFin.Domain.Residences.Events;

public sealed record ResidenceCreatedDomainEvent (
    Guid ResidenceId
    ) : IDomainEvent;