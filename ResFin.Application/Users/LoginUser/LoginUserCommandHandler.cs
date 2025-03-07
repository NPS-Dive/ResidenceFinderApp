namespace ResFin.Application.Users.LoginUser;

public sealed class LoginUserCommandHandler
{
    private readonly IJwtService _jwtService;

    public LoginUserCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<Result<AccessTokenResponse>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _jwtService.GetAccessTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
        }

        return new AccessTokenResponse(result.Value);
    }
}