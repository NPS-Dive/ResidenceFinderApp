namespace ResFin.Domain.Residences.Events.Reservations.Events;

public sealed record ReservationConfirmedDomainEvent ( 
    Guid ReservationId
)
    : IDomainEvent;