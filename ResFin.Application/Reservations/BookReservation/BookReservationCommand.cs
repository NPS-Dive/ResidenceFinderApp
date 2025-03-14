namespace ResFin.Application.Reservations.BookReservation;

public record BookReservationCommand (
    Guid ResidenceId,
    Guid UserId,
    DateOnly BeginDate,
    DateOnly EndDate
    )
    : ICommand<Guid>;