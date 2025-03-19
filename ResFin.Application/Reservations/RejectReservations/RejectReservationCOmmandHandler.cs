using ResFin.Domain.Reservations;

namespace ResFin.Application.Reservations.RejectReservations;

public class RejectReservationCOmmandHandler : ICommandHandler<RejectReservationCommand>
    {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RejectReservationCOmmandHandler (
        IDateTimeProvider dateTimeProvider,
        IReservationRepository bookingRepository,
        IUnitOfWork unitOfWork )
        {
        _reservationRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        }

    public async Task<Result> Handle (
        RejectReservationCommand request,
        CancellationToken cancellationToken )
        {
        var booking = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);

        if (booking is null)
            {
            return Result.Failure(ReservationErrors.NotFound);
            }

        var result = booking.Reject(_dateTimeProvider.UtcNow);

        if (result.IsFailure)
            {
            return result;
            }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
        }
    }