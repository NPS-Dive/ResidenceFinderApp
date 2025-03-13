using IAuthenticationService = ResFin.Application.Abstractions.Authentication.IAuthenticationService;

namespace ResFin.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private const string PasswordCredentialType = "password";
    private readonly HttpClient _httpClient;

    public AuthenticationService ( HttpClient httpClient )
        {
        _httpClient = httpClient;
        }

    public async Task<string> RegisterAsync (
        User user,
        string password,
        CancellationToken cancellationToken = default
        )
        {
        var userReprentationModel = UserRepresentationModel.FromUser(user);
        userReprentationModel.Credentials = new CredentialRepresentationModel[]
        {
            new()
            {
                Value = password,
                Temporary = false,
                Type = PasswordCredentialType
            }
        };

        var response = await _httpClient.PostAsJsonAsync(
            "users",
            userReprentationModel,
            cancellationToken
            );


        var identityId = ExtractIdentityIdFromLocationHeader(response);

        return identityId;
        }

    private string ExtractIdentityIdFromLocationHeader (
        HttpResponseMessage response )
        {
        const string usersSegmentName = "users/";
        var locationHeader = response.Headers.Location?.PathAndQuery;

        if (locationHeader is null)
            {
            throw new InvalidOperationException("Location header cannot be NULL");
            }

        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase
            );

        var userIdentityId = locationHeader.Substring(
            userSegmentValueIndex + usersSegmentName.Length
            );

        return userIdentityId;
        }
    }