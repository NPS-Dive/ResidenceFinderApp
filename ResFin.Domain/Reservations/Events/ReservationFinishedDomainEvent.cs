namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationFinishedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;