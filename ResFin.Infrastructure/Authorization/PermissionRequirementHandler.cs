namespace ResFin.Infrastructure.Authorization;

public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserContext _userContext; // Your existing user context service

    public PermissionRequirementHandler ( IUserContext userContext )
    {
        _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
    }

    protected override Task HandleRequirementAsync ( AuthorizationHandlerContext context, PermissionRequirement requirement )
    {
        // Replace this with your actual permission-checking logic
        var userPermissions = _userContext.GetUserPermissions(); // Hypothetical method
        if (userPermissions != null && userPermissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement); // User has the permission
        }

        return Task.CompletedTask;
    }
}