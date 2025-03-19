using ResFin.Domain.Reservations;

namespace ResFin.Infrastructure.Repositories;

internal sealed class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
    private static readonly ReservationStatus[] ActiveReservationStatusArray =
    {
        ReservationStatus.Reserved,
        ReservationStatus.Confirmed,
        ReservationStatus.Completed,
        ReservationStatus.Finished
    };

    public ReservationRepository ( ApplicationDbContext dbContext )
        : base(dbContext)
        {
        }

    public async Task<bool> IsOverlappingAsync (
        Residence residence,
        Duration duration,
        CancellationToken cancellationToken = default )
        {
        return await DbContext
            .Set<Reservation>()
            .AnyAsync(reservation =>
                                     reservation.ResidenceId == residence.Id && 
                                     reservation.Duration.BeginDate <= duration.EndDate && 
                                     reservation.Duration.EndDate >= duration.BeginDate &&
                                     ActiveReservationStatusArray.Contains(reservation.Status),
                cancellationToken);
        }
    }