﻿namespace ResFin.Infrastructure.Authentication.Models;

public sealed class AuthorizationToken
    {
    [JsonPropertyName("access_token")] public string AccessToken { get; init; } = string.Empty;
    }