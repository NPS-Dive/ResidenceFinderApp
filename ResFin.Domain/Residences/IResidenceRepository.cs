
namespace ResFin.Domain.Residences;

public interface IResidenceRepository
{
    Task<Residence?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default );
    Task AddAsync (Residence residence);
    }