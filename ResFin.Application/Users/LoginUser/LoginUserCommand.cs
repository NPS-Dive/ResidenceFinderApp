namespace ResFin.Application.Users.LoginUser;

 public sealed record LoginUserCommand(
     string Email,
     string Password
     ): ICommand<AccessTokenResponse>;