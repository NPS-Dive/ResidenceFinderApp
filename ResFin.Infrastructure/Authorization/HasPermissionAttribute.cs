using Microsoft.AspNetCore.Authorization;

namespace ResFin.Infrastructure.Authorization;

public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission)
        :base(permission)
        {
            
        }
    }