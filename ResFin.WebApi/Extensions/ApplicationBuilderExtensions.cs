


using System.Net.Sockets;

namespace ResFin.WebApi.Extensions
    {
    public static class ApplicationBuilderExtensions
        {
            public static void ApplyMigrations(this IApplicationBuilder app)
            {
                using var scope = app.ApplicationServices.CreateScope();
                using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                dbContext.Database.Migrate();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket error: {ex.Message}, ErrorCode: {ex.ErrorCode}");
                throw;
            }
            }

        public static void UseCustomExceptionHandler ( this IApplicationBuilder app )
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
        }
    }
