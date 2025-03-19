using ResFin.Domain.Reservations;

namespace ResFin.Application.Reservations.BookReservation;

internal sealed class ReservationReservedDomainEventHandler : INotificationHandler<ReservationReservedDomainEvent>
    {
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IResidenceRepository _residenceRepository;

    public ReservationReservedDomainEventHandler (
        IReservationRepository reservationRepository,
        IUserRepository userRepository,
        IEmailService emailService,
        IResidenceRepository residenceRepository )
        {
        _reservationRepository = reservationRepository;
        _userRepository = userRepository;
        _emailService = emailService;
        _residenceRepository = residenceRepository;
        }

    public async Task Handle ( ReservationReservedDomainEvent notification, CancellationToken cancellationToken )
        {
        var reservation = await _reservationRepository.GetByIdAsync(notification.ReservationId, cancellationToken);
        if (reservation is null)
            {
            return;
            }

        var user = await _userRepository.GetByIdAsync(reservation.UserId, cancellationToken);
        if (user is null)
            {
            return;
            }

        var residence = await _residenceRepository.GetByIdAsync(reservation.ResidenceId, cancellationToken);
        await _emailService.SendAsync(
            user.Email,
            $"Reservation of '{residence.Name}' is Booked",
            $"You Have 15 minutes to confirm your reservation of '{residence.Name}' for {reservation.Duration} days of staying!");
        }
    }