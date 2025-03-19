namespace ResFin.Application.Reservations.ConfirmReservation;

public sealed record ConfirmReservationCommand(
    Guid ReservationId)
    : ICommand;
