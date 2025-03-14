namespace ResFin.Application.Users.RegisterUser;

public sealed record RegisterUserCommand (
    string FirstName,
    string Lastname,
    string Email,
   string phone,
    string cellPhone,
    Address address,
    UserType UserType,
    string Password
    ) : ICommand<Guid>;