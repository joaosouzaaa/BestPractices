using BestPractices.Api.Extensions;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> RegisterAsync([FromBody] UserSaveRequest userSaveRequest) =>
            await _userService.RegisterAsync(userSaveRequest);

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<BearerTokenResponse> LoginAsync([FromBody] UserSaveRequest userSaveRequest) =>
            await _userService.LoginAsync(userSaveRequest);

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserResponseClient> GetCurrentLoggedInUserAsync() =>
            await _userService.GetUserByEmailAsync(HttpContext.GetUserEmail());

        [HttpDelete("delete_user")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> DeleteAsync([FromQuery] string userId) =>
            await _userService.DeleteAsync(userId);

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("update_user")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> UpdateAsync([FromBody] UserUpdateRequest updateRequest) =>
            await _userService.UpdateAsync(updateRequest);

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<List<UserResponseClient>> GetAllAsync() =>
            await _userService.FindAllEntitiesAsync();

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getall_pagination")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<PageList<UserResponseClient>> GetAllWithPaginationAsync([FromQuery] PageParams pageParams) =>
           await _userService.FindAllEntitiesWithPaginationAsync(pageParams);
    }
}
