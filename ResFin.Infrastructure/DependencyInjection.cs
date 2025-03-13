using AuthenticationOptions = ResFin.Infrastructure.Authentication.AuthenticationOptions;
using AuthenticationService = ResFin.Infrastructure.Authentication.AuthenticationService;
using IAuthenticationService = ResFin.Application.Abstractions.Authentication.IAuthenticationService;

namespace ResFin.Infrastructure;

public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructure (
        this IServiceCollection services,
        IConfiguration configuration )
        {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        AddPersistence(services, configuration);

        AddAuthentication(services, configuration);

        AddAuthorization(services);

        return services;
        }

    private static void AddPersistence ( IServiceCollection services, IConfiguration configuration )
        {
        var connectionString = configuration.GetConnectionString("Database") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IResidenceRepository, ResidenceRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        }

    private static void AddAuthentication ( IServiceCollection services, IConfiguration configuration )
        {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.Configure<KeyCloakOptions>(configuration.GetSection("keycloak"));
        services.AddTransient<AdminAuthorizationDelegatingHandler>();
        services.AddHttpClient<IAuthenticationService, AuthenticationService>(( ServiceProvider, HttpClient ) =>
            {
                var keyCloakOptions = ServiceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;
                HttpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
            })
            .AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IJwtService, JwtService>(( ServiceProvider, HttpClient ) =>
        {
            var keyCloakOptions = ServiceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;
            HttpClient.BaseAddress = new Uri(keyCloakOptions.TokenUrl);
        });

        }

    private static void AddAuthorization ( IServiceCollection services )
        {
        services.AddScoped<AuthorizationService>();
        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();
        }
    }