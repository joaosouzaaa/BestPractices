using BestPractices.Api.Extensions;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Business.Settings.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, ITokenManagerService tokenManagerService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> RegisterAsync(UserSaveRequest userSaveRequest) =>
            await _userService.RegisterAsync(userSaveRequest);

        [HttpGet("confirmEmail")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<RedirectResult> ConfirmEmailAsync(string email, string token)
        {
            var confirmResult = await _userService.ConfirmEmailAsync(email, token);
            
            if (confirmResult)
                return Redirect("http:localhost:3000/login");

            return Redirect("http:localhost:3000/login?confirmed=false");
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<BearerTokenResponse> LoginAsync(UserSaveRequest userSaveRequest) =>
            await _userService.LoginAsync(userSaveRequest);

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserResponseClient> GetCurrentLoggedInUserAsync() =>
            await _userService.GetUserByEmailAsync(HttpContext.GetUserEmail());

        [HttpDelete("deleteuser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> DeleteAsync(string userId) =>
            await _userService.DeleteAsync(userId);
    }
}
