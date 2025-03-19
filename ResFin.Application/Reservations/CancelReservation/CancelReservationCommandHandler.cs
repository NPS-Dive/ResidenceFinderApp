using ResFin.Domain.Reservations;

namespace ResFin.Application.Reservations.CancelReservation;

internal sealed class CancelReservationCommandHandler : ICommandHandler<CancelReservationCommand>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelReservationCommandHandler (
            IDateTimeProvider dateTimeProvider,
            IReservationRepository bookingRepository,
            IUnitOfWork unitOfWork )
        {
            _dateTimeProvider = dateTimeProvider;
            _reservationRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle (
            CancelReservationCommand request,
            CancellationToken cancellationToken )
        {
            var booking = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);

            if (booking is null)
            {
                return Result.Failure(ReservationErrors.NotFound);
            }

            var result = booking.Cancel(_dateTimeProvider.UtcNow);

            if (result.IsFailure)
            {
                return result;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }