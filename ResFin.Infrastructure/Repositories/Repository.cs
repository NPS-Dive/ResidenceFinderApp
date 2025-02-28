namespace ResFin.Infrastructure.Repositories;

internal abstract class Repository<T>
where T : BaseEntity
    {
    protected readonly ApplicationDbContext DbContext;

    protected Repository ( ApplicationDbContext dbContext )
        {
        DbContext = dbContext;
        }

    public async Task<T?> GetByIdAsync ( Guid id, CancellationToken cancellationToken = default )
        {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            DbContext.AddAsync(entity);
        }
    }