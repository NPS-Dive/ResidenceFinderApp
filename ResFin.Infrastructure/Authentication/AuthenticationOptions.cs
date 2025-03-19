namespace ResFin.Infrastructure.Authentication;

public class AuthenticationOptions
    {
    public string Audienec { get; init; } = string.Empty;
    public string MetaDataUrl { get; set; } = string.Empty;
    public bool RequireHttpsMetaData { get; init; }
    public string Issuer { get; set; } = string.Empty;
    }