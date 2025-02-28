namespace ResFin.Infrastructure.Email;

internal sealed class EmailService : IEmailService
    {
    public Task SendAsync ( Domain.Users.Email recipientEmail, string subject, string body )
        {
        return Task.CompletedTask;
        }
    }