namespace ResFin.Application.Reservations.BookReservation;

public class BookReservationCommandValidator : AbstractValidator<BookReservationCommand>
    {
        public BookReservationCommandValidator()
        {
            RuleFor(c=>c.UserId)
                .NotEmpty();

            RuleFor(c => c.ResidenceId)
                .NotEmpty();

            RuleFor(c=>c.BeginDate)
                .LessThan(c=>c.EndDate);

        }
    }