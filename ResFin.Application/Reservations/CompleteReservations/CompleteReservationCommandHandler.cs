using ResFin.Domain.Reservations;

namespace ResFin.Application.Reservations.CompleteReservations;

internal sealed class CompleteReservationCommandHandler   :ICommandHandler<CompleteReservationCommand>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Result> Handle ( CompleteReservationCommand request, CancellationToken cancellationToken )
    {
        var booking = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);

        if (booking is null)
        {
            return Result.Failure(ReservationErrors.NotFound);
        }

        var result = booking.Complete(_dateTimeProvider.UtcNow);

        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    }