

namespace ResFin.Domain.Reviews;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default );
    Task AddAsync ( Review review);
    void Add ( Review review);
    }