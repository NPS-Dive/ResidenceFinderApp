namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationRejectedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;