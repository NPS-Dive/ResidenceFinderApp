namespace ResFin.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
    {
    public static string GetIdentityId ( this ClaimsPrincipal? principal )
        {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
               throw new ApplicationException("User Identity is unavailable");
        }
    }