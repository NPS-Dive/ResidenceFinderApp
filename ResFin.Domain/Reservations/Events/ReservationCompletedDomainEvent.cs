namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationCompletedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;