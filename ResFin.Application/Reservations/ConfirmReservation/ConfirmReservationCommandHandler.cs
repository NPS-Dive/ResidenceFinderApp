using ResFin.Application.Abstractions.Messeging;
using ResFin.Domain.Reservations;

namespace ResFin.Application.Reservations.ConfirmReservation;

internal sealed class ConfirmReservationCommandHandler    : ICommandHandler<ConfirmReservationCommand>
    {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmReservationCommandHandler(
        IDateTimeProvider dateTimeProvider, 
        IReservationRepository reservationRepository, 
        IUnitOfWork unitOfWork)
    {
        _dateTimeProvider = dateTimeProvider;
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle (
        ConfirmReservationCommand request,
        CancellationToken cancellationToken )
    {
        var booking = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);

        if (booking is null)
        {
            return Result.Failure(ReservationErrors.NotFound);
        }

        var result = booking.Confirm(_dateTimeProvider.UtcNow);

        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    }