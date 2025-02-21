namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationReservedDomainEvent (
    Guid ReservationId
    )
    : IDomainEvent;