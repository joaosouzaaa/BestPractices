using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using BestPractices.Domain.Extensions;
using Microsoft.AspNetCore.Identity;

namespace BestPractices.ApplicationService.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IValidationHandler validationHandler, INotificationHandler notificationHandler, IUserRepository userRepository) 
            : base(validationHandler, notificationHandler)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(UserSaveRequest userSaveRequest)
        {
            var user = userSaveRequest.MapTo<UserSaveRequest, User>();
            user.Client = CreateNullClient();

            var result = await _userRepository.RegisterAsync(user);

            if(result != IdentityResult.Success)
            {
                this._notificationHandler.AddNotification("Unexpected error", EMessage.UnexpectedError.Description());
            }
        }

        public async Task<UserResponse> LoginAsync(UserSaveRequest userSaveRequest)
        {
            var result = await _userRepository.LoginAsync(userSaveRequest.Email, userSaveRequest.Password);

            if(result == SignInResult.Failed)
            {
                this._notificationHandler.AddNotification("Login", EMessage.InvalidCredencials.Description());
            }

            var user = userSaveRequest.MapTo<UserSaveRequest, User>();
            var userResponse = user.MapTo<User, UserResponse>();

            return userResponse;
        }

        public async Task<UserResponseClient> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if(user == null)
            {
                this._notificationHandler.AddNotification($"{email}", EMessage.NotFound.Description().FormatTo($"{email}"));
            }

            var userResponse = user.MapTo<User, UserResponseClient>();

            return userResponse;
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
