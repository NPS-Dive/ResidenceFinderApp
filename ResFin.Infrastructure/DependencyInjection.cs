using Asp.Versioning;
using Quartz;
using ResFin.Application.Abstractions.Caching;
using ResFin.Infrastructure.Caching;
using ResFin.Infrastructure.Outbox;
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

        services.AddScoped<IUserContext, UserContext>();

        AddCaching(services, configuration);
        AddHealthCheck(services, configuration);
        AddApiVersioning(services);
        AddBackgroundJob(services, configuration);

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
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
        }

    private static void AddCaching ( IServiceCollection services, IConfiguration configuration )
        {
        var connectionString = configuration.GetConnectionString("Cache") ??
                               throw new ArgumentNullException(nameof(configuration));
        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
        services.AddSingleton<ICacheService, CacheService>();
        }

    private static void AddHealthCheck ( IServiceCollection services, IConfiguration configuration )
        {
        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!)
            .AddRedis(configuration.GetConnectionString("Cache")!)
            .AddUrlGroup(new Uri(configuration["KeyCloak:BaseUrl"]!), HttpMethod.Get, "keycloak");
        }

    private static void AddApiVersioning ( IServiceCollection services )
        {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader(),
                    new UrlSegmentApiVersionReader());
            })
            .AddMvc()
            .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
        }

    private static void AddBackgroundJob ( IServiceCollection services, IConfiguration configuration )
        {
        services.Configure<OutBoxOptions>(configuration.GetSection("OutBox"));

        services.AddQuartz();

        services.AddQuartzHostedService(options =>
            options.WaitForJobsToComplete = true
        );

        services.AddQuartzHostedService(Options =>
            Options.WaitForJobsToComplete = true
        );

        }
    }