namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationRejectedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;