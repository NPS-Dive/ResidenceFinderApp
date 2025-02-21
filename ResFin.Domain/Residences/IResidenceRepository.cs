
using ResFin.Domain.Residences.Events.Reservations;

namespace ResFin.Domain.Residences;

public interface IResidenceRepository
{
    Task<Residence?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default );
    Task AddAsync (Residence residence);
    Task<bool> IsOverlappingAsync ( Residence residence, Duration duration, CancellationToken cancellationToken );
    }