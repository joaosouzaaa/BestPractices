using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace BestPractices.ApplicationService.Services
{
    public class UserService : BaseServiceNoValidation, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManagerService _tokenManagerService;
        
        public UserService(IUserRepository userRepository, ITokenManagerService tokenManagerService, INotificationHandler notification) : base(notification)
        {
            _tokenManagerService = tokenManagerService;
        }

        public async Task<bool> RegisterAsync(UserSaveRequest userSaveRequest)
        {
            var user = userSaveRequest.MapTo<UserSaveRequest, User>();
            user.Client = CreateNullClient();

            var result = await _userRepository.RegisterAsync(user);

            if (!result.Succeeded)
                return _notification.AddNotification(new DomainNotification("Identity", string.Join(", ", result.Errors)));

            return result.Succeeded;
        }

        public async Task<string> LoginAsync(UserSaveRequest userSaveRequest)
        {
            var result = await _userRepository.LoginAsync(userSaveRequest.Email, userSaveRequest.Password);

            if (!result.Succeeded)
            {
                _notification.AddNotification("Login", EMessage.InvalidCredencials.Description());
                return null;
            }

            var user = userSaveRequest.MapTo<UserSaveRequest, User>();
            var userResponse = user.MapTo<User, UserResponse>();

            return await _tokenManagerService.GenerateAccessToken(userResponse);
        }

        public async Task<UserResponseClient> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if(user == null)
                _notification.AddNotification($"{email}", EMessage.NotFound.Description().FormatTo($"{email}"));

            return user.MapTo<User, UserResponseClient>();
        }

        private Client CreateNullClient()
        {
            var client = new Client()
            {
                Name = "",
                LastName = "",
                BirthDate = DateTime.UtcNow,
                DocumentNumber = ""
            };

            return client;
        }
    }
}
