namespace ResFin.Application.Reservations.GetReservation;

public sealed record GetReservationQuery (
    Guid ReservationId
    ) : IQuery<ReservationResponse>;