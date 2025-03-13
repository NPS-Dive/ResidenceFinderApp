namespace ResFin.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
    {
    public UserRepository ( ApplicationDbContext dbContext )
        : base(dbContext)
        {
        }

        public override void Add(User entity)
        {
            foreach (var role in entity.Roles)
            {
                DbContext.Attach(role);
            }

            DbContext.Add(entity);
        }

        public override async Task AddAsync(User entity)
        {
            foreach (var role in entity.Roles)
            {
                DbContext.Attach(role);
            }

            await DbContext.AddAsync(entity);
        }
    }