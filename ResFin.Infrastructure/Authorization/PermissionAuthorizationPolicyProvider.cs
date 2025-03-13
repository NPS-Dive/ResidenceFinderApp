using Microsoft.AspNetCore.Authorization;

namespace ResFin.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
    private readonly AuthorizationOptions _authorizationOptions;
    public PermissionAuthorizationPolicyProvider ( IOptions<AuthorizationOptions> options, AuthorizationOptions authorizationOptions )
        : base(options)
        {
        _authorizationOptions = authorizationOptions;
        }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync ( string policyName )
        {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null)
            {
            return policy;
            }

        var permissionPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();

        _authorizationOptions.AddPolicy(policyName, permissionPolicy);

        return permissionPolicy;
        }
    }