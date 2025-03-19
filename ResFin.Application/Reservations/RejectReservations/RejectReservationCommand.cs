namespace ResFin.Application.Reservations.RejectReservations;

public record RejectReservationCommand(
    Guid ReservationId)
    :ICommand;