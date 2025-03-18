//namespace ResFin.Infrastructure
//{
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        private readonly IDateTimeProvider _dateTimeProvider;

//        public ApplicationDbContextFactory(IDateTimeProvider dateTimeProvider)
//        {
//            _dateTimeProvider = dateTimeProvider;
//        }

//        public ApplicationDbContext CreateDbContext ( string[] args )
//        {
//            // Build configuration (e.g., from appsettings.json)
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();

//            // Get the connection string
//            var connectionString = "Host=localhost;Port=5432;Database=resfin;Username=postgres;Password=postgress";

//            // Configure DbContextOptions
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            optionsBuilder.UseNpgsql(connectionString); // Use Npgsql for Postgres; adjust for your provider

//            return new ApplicationDbContext(optionsBuilder.Options, _dateTimeProvider);
//        }
//    }
//}