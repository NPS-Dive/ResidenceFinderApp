namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationCompletedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;