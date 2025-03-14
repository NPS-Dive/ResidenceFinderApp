using Asp.Versioning;

namespace ResFin.WebApi.Controllers.Users
    {
    [ApiController]
    [ApiVersion(ApiVersions.V1, Deprecated = true)]
    [ApiVersion(ApiVersions.V2)]
    [ApiVersion(ApiVersions.V3)]
    [Route("api/[controller]/v{version:apiVersion}/[action]")]

    public class UsersController : ControllerBase
        {
        private readonly ISender _sender;

        public UsersController ( ISender sender )
            {
            _sender = sender;
            }


        [HttpGet]
        [Authorize(Roles = Roles.Registered)]
        [HasPermission(Permissions.UsersRead)]
        [MapToApiVersion(ApiVersions.V2)]
        public async Task<IActionResult> GetLoggedInUserV2 ( CancellationToken cancellationToken )
            {
            var query = new GetLoggedInUserQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
            }

        [HttpGet]
        [HasPermission(Permissions.UsersRead)]
        [MapToApiVersion(ApiVersions.V3)]
        public async Task<IActionResult> GetLoggedInUserV3 ( CancellationToken cancellationToken )
            {
                var query = new GetLoggedInUserQuery();
                var result = await _sender.Send(query, cancellationToken);
                return Ok(result.Value);
            }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register (
            RegisterUserRequest request,
            CancellationToken cancellationToken )
            {
            var command = new RegisterUserCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Phone,
                request.CellPhone,
                request.Address,
                request.UserType,
                request.Password
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                {
                return BadRequest(result.Error);
                }

            return Ok(result.Value);
            }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn (
            LoginUserRequest request,
            CancellationToken cancellationToken )
            {
            var command = new LoginUserCommand(
                request.Email,
                request.Password
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                {
                return Unauthorized(result.Error);
                }

            return Ok(result.Value);
            }
        }
    }
