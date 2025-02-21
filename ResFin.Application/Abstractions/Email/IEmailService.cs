namespace ResFin.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Users.Email recipientEmail, string subject, string body);
}