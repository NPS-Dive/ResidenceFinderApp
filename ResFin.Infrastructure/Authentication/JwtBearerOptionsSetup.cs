namespace ResFin.Infrastructure.Authentication;

public class JwtBearerOptionsSetup   :IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _authenticationOptions;

    public JwtBearerOptionsSetup(IOptions<AuthenticationOptions> authenticationOptions)
    {
        _authenticationOptions = authenticationOptions.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _authenticationOptions.Audienec;
        options.MetadataAddress = _authenticationOptions.MetaDataUrl;
        options.RequireHttpsMetadata = _authenticationOptions.RequireHttpsMetaData;
        options.TokenValidationParameters.ValidIssuer = _authenticationOptions.Issuer;
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
      Configure(options);
    }
}