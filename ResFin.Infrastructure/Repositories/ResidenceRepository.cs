namespace ResFin.Infrastructure.Repositories;

internal sealed class ResidenceRepository : Repository<Residence>, IResidenceRepository
    {
    public ResidenceRepository ( ApplicationDbContext dbContext ) 
        : base(dbContext)
        {
        }
    }