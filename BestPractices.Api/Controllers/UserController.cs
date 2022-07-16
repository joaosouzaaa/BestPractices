using BestPractices.Api.Extensions;
using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;
using BestPractices.ApplicationService.Interfaces;
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

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<string> LoginAsync(UserSaveRequest userSaveRequest) =>
            await _userService.LoginAsync(userSaveRequest);

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserResponseClient> GetCurrentLoggedInUserAsync() =>
            await _userService.GetUserByEmailAsync(HttpContext.GetUserEmail());
    }
}
