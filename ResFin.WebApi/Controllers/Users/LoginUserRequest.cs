namespace ResFin.WebApi.Controllers.Users;

public sealed record LoginUserRequest
(
    string Email,
    string Password
);