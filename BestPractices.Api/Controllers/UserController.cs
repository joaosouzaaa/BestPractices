using BestPractices.Api.Extensions;
using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.Business.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenManagerService _tokenManagerService;

        public UserController(IUserService userService, ITokenManagerService tokenManagerService)
        {
            _userService = userService;
            _tokenManagerService = tokenManagerService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task RegisterAsync(UserSaveRequest userSaveRequest)
        {
            await _userService.RegisterAsync(userSaveRequest);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<string> LoginAsync(UserSaveRequest userSaveRequest)
        {
            var loginResult = await _userService.LoginAsync(userSaveRequest);

            return await _tokenManagerService.GenerateAccessToken(loginResult);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserResponseClient> GetCurrentLoggedInUserAsync()
        {
            var email = HttpContext.GetUserEmail();

            return await _userService.GetUserByEmailAsync(email);
        }
    }
}
