namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationCanceledDomainEvent(
    Guid ReservationId
)
    : IDomainEvent;