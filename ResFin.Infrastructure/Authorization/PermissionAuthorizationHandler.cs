using Microsoft.AspNetCore.Authorization;

namespace ResFin.Infrastructure.Authorization;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceProvider _serviceProvider;

    public PermissionAuthorizationHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            PermissionRequirement requirement
            )
        {
            if (context.User.Identity is not { IsAuthenticated: true})
            {
                return;
            }

            using var scope = _serviceProvider.CreateScope();

            var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();
            var identityId = context.User.GetIdentityId();
          HashSet<string>  permissions = await authorizationService.GetPermissionsForUserAsync(identityId);

          if (permissions.Contains(requirement.Permission))
          {
               context.Succeed(requirement);
          }
        }
    }