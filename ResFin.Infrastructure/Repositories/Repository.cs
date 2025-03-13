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

        public virtual void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public async virtual Task AddAsync(T entity)
        {
           await DbContext.AddAsync(entity);
        }
    }