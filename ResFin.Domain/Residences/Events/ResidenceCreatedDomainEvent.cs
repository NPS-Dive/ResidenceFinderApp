namespace ResFin.Domain.Residences.Events;

public record ResidenceCreatedDomainEvent (
    Guid ResidenceId
    ) : IDomainEvent;