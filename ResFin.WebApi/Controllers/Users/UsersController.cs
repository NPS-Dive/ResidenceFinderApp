using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResFin.Application.Users.GetLoggedInUser;
using ResFin.Application.Users.LoginUser;
using ResFin.Application.Users.RegisterUser;
using ResFin.Infrastructure.Authorization;

namespace ResFin.WebApi.Controllers.Users
    {
    [ApiController]
    [Route("api/[controller]/[action]")]

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
        public async Task<IActionResult> GetLoggedInUser ( CancellationToken cancellationToken )
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
