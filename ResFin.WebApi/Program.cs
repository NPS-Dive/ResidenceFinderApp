using Asp.Versioning;
using Asp.Versioning.Builder;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ResFin.WebApi.Controllers.Reservations;
using ResFin.WebApi.OpenApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add serilog
builder.Host.UseSerilog(( context, configuration ) =>
        configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDbContext).Assembly));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddHealthChecks().AddCheck<CustomSqlHealthCheck>("custom-sql");

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptionsList = app.DescribeApiVersions();

        foreach (var description in descriptionsList)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json ";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });

    app.ApplyMigrations();
    app.SeedData();
    }

app.UseHttpsRedirection();

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

ApiVersionSet apiVersionSet = app
    .NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

var routeGroupBuilder= app.MapGroup("api/v{version:apiVersion}").WithApiVersionSet(apiVersionSet);

routeGroupBuilder.MapReservationEndPoints();

app.MapHealthChecks("health", new HealthCheckOptions()
    {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();

public partial class Program;


//Custom Methods
  //=====================================================




//public class CustomSqlHealthCheck(ISqlConnectionFactory sqlConnectionFactory) : IHealthCheck
//{
//    public async Task<HealthCheckResult> CheckHealthAsync(
//        HealthCheckContext context, 
//        CancellationToken cancellationToken = default
//        )
//    {
//        try
//        {
//            using var connection = sqlConnectionFactory.CreateConnection();
//            await connection.ExecuteScalarAsync("Select 1;");
//            return HealthCheckResult.Healthy();
//        }
//        catch (Exception healthException)
//        {
//            return   HealthCheckResult.Unhealthy(exception: healthException);
//        }
//    }
//}