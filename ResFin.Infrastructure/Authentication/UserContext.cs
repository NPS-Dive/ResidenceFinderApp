using Microsoft.AspNetCore.Http;

namespace ResFin.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
    {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext ( IHttpContextAccessor httpContextAccessor )
        {
        _httpContextAccessor = httpContextAccessor;
        }

    public Guid UserId =>
        _httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        throw new ApplicationException("User context is unavailable");

    public string IdentityId =>
        _httpContextAccessor
            .HttpContext
            .User
            .GetIdentityId() ??
        throw new ApplicationException("User context is unavailable");

    public IEnumerable<string> GetUserPermissions ()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            throw new ApplicationException("User context is unavailable");
        }

        // Extract permissions from claims (adjust claim type as needed)
        return user.FindAll("permissions") // Assuming permissions are stored in a "permissions" claim
            .Select(claim => claim.Value)
            .ToList();
    }
    }