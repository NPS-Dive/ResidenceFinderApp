namespace ResFin.Domain.Users;

public interface IUserRepository
    {
    Task<User?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default );
    Task AddAsync ( User user );
    void Add ( User user );
    }