namespace ResFin.Application.Reservations.CancelReservation;

public record CancelReservationCommand(
    Guid ReservationId)
    :ICommand;