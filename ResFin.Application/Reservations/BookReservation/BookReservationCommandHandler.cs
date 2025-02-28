namespace ResFin.Application.Reservations.BookReservation;

internal sealed class BookReservationCommandHandler : ICommandHandler<BookReservationCommand, Guid>
    {

    private readonly IUserRepository _userRepository;
    private readonly IResidenceRepository _residenceRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    private readonly IDateTimeProvider _dateTimeProvider;


    public BookReservationCommandHandler (
        IUserRepository userRepository,
        IResidenceRepository residenceRepository,
        IReservationRepository reservationRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService,
        IDateTimeProvider dateTimeProvider )
        {
        _userRepository = userRepository;
        _residenceRepository = residenceRepository;
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
        _dateTimeProvider = dateTimeProvider;
        }

    public async Task<Result<Guid>> Handle ( BookReservationCommand request, CancellationToken cancellationToken )
        {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            {
            return Result.Failure<Guid>(UserErrors.NotFound);
            }

        var residence = await _residenceRepository.GetByIdAsync(request.ResidenceId, cancellationToken);

        if (residence is null)
            {
            return Result.Failure<Guid>(ResidenceErrors.NotFound);
            }

        var duration = Duration.Create(request.BeginDate, request.EndDate);

        if (await _reservationRepository.IsOverlappingAsync(residence, duration, cancellationToken))
            {
            return Result.Failure<Guid>(ReservationErrors.Overlap);
            }

        try
            {
            var reservation = Reservation.Reserve(
                residence,
                user.Id,
                duration,
                _dateTimeProvider.UtcNow,
                _pricingService);

            await _reservationRepository.AddAsync(reservation);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return reservation.Id;
            }
        catch (ConcurrencyException)
            {
            return Result.Failure<Guid>(ReservationErrors.Overlap);
            }
        }
    }