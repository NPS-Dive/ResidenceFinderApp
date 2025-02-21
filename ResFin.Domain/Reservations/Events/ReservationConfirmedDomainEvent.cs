namespace ResFin.Domain.Residences.Events.Reservations.Events;

public record ReservationConfirmedDomainEvent ( 
    Guid ReservationId
)
    : IDomainEvent;