namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationReservedDomainEvent (
    Guid ReservationId
    )
    : IDomainEvent;