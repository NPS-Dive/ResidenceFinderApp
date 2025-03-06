namespace ResFin.WebApi.Controllers.Reservations
    {
        public sealed record BookReservationRequest(
            Guid ResidenceId,
            Guid UserId,
            DateOnly BeginDate,
            DateOnly EndDate
            );

        
    }