namespace ResFin.Application.Reservations.CompleteReservations;

public sealed record CompleteReservationCommand (
    Guid ReservationId)
    : ICommand;