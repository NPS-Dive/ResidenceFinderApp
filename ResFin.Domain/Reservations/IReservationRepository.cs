
namespace ResFin.Domain.Residences.Events.Reservations;

public interface IReservationRepository
    {
    Task<Reservation?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default );
    Task AddAsync ( Reservation reservation );
    void Add ( Reservation reservation );
    Task<bool> IsOverlappingAsync (
        Residence residence,
        Duration duration,
        CancellationToken cancellationToken = default
        );
    }