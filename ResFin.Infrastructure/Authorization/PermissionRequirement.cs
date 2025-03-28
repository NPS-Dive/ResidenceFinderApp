﻿namespace ResFin.Infrastructure.Authorization;

public sealed class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement ( string permission )
        {
            Permission = permission ?? throw new ArgumentNullException(nameof(permission));
        }
    }