namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationFinishedDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;