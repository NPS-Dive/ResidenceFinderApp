namespace ResFin.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
    {
    public static string GetIdentityId ( this ClaimsPrincipal? principal )
        {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
               throw new ApplicationException("User Identity is unavailable");
        }
    public static Guid GetUserId ( this ClaimsPrincipal? principal )
        {
        var userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out Guid parsedUserId) ?
            parsedUserId :
             throw new ApplicationException("User Identifier is unavailable");
        }


    }