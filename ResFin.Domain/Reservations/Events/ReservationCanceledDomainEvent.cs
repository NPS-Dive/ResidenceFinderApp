namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationCanceledDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;