namespace ResFin.WebApi.Controllers.Users;

public sealed record RegisterUserRequest (
    string FirstName,
    string LastName,
   string Email,
    string Phone,
    string CellPhone,
    Address Address,
    UserType UserType,
    string Password
    );