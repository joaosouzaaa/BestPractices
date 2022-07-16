using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Interfaces.EmailService;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Entities.Email;
using BestPractices.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace BestPractices.ApplicationService.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, ITokenManagerService tokenManagerService,
                           IEmailService emailService,
                           IValidate<User> validate, INotificationHandler notification)
                           : base(validate, notification)
        {
            _userRepository = userRepository;
            _tokenManagerService = tokenManagerService;
            _emailService = emailService;
        }

        public async Task<bool> RegisterAsync(UserSaveRequest userSaveRequest)
        {
            var user = userSaveRequest.MapTo<UserSaveRequest, User>();
            user.Client = CreateNullClient();

            if (!await ValidatedAsync(user))
                return false;

            var result = await _userRepository.RegisterAsync(user);

            if (!result.Succeeded)
                AddIdentityErrors(result.Errors);

            if (_notification.HasNotification() == false)
            {
                var token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
                var body = $"<html><head> <meta charset='utf-8'></head><body style='margin: 0; padding: 0;'> <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-top:20px;text-align:start;color:#6F6F6F'> <tr> <table align='center' style='text-align:start;color:#6F6F6F'> <tr> <td> <br> <br> <span>Click on the button at the end to confirm your email.</span><br> <br> </td> </tr> </table> </tr> <tr> <td> <table align='center'> <tr> <td> <br> <br> <a style='text-align: center; text-decoration: none; padding: 15px 30px; text-align: center; background-color: #74CCDA; color: white; border-radius: 5px; border: none; cursor: pointer; margin: 0 auto;' href='https://localhost:7269/api/User/confirmEmail?email={user.Email}&token={token}'> Confirm Email </a> </td> </tr> </table> </td> </tr> </table></body></html>";
                return await SendEmailAsync(body, user.Email, user.UserName);
            }

            return false;
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                var result = await _userRepository.ConfirmEmailAsync(user, token);

                if (!result.Succeeded)
                    return _notification.AddNotification(new DomainNotification("Identity", string.Join(", ", result.Errors)));

                return result.Succeeded;
            }

            return false;
        }

        public async Task<BearerTokenResponse> LoginAsync(UserSaveRequest userSaveRequest)
        {
            var result = await _userRepository.LoginAsync(userSaveRequest.Email, userSaveRequest.Password);

            if (!result.Succeeded)
            {
                _notification.AddNotification("Login", EMessage.InvalidCredencials.Description());
                return null;
            }

            //var user = await _userRepository.GetUserByEmailAsync(userSaveRequest.Email);

            //if (user.EmailConfirmed == false)
            //{
            //    _notification.AddNotification("User", "Email is not confirmed");
            //    return null;
            //}

            return await _tokenManagerService.GenerateAccessToken(userSaveRequest.Email);
        }

        public async Task<bool> UpdateAsync(UserUpdateRequest updateRequest)
        {
            var user = updateRequest.MapTo<UserUpdateRequest, User>();

            if (!await ValidatedAsync(user))
                return false;

            var updateResult = await _userRepository.UpdateAsync(user);

            if (!updateResult.Succeeded)
                AddIdentityErrors(updateResult.Errors);

            if (_notification.HasNotification() == false)
                return updateResult.Succeeded;

            return false;
        }

        public async Task<UserResponseClient> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
                _notification.AddNotification($"{email}", EMessage.NotFound.Description().FormatTo($"{email}"));

            return user.MapTo<User, UserResponseClient>();
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            if (!await _userRepository.HaveObjectInDb(u => u.Id == userId))
                return _notification.AddNotification(new DomainNotification("User", EMessage.NotFound.Description().FormatTo("User")));

            var deleteResult = await _userRepository.DeleteAsync(userId);

            if (!deleteResult.Succeeded)
                return !deleteResult.Succeeded;

            return deleteResult.Succeeded;
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

        private void AddIdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
                _notification.AddNotification("Identity", error.Description);
        }

        private SystemEmail SetupEmail(string body, string subject, string to, string clientName)
        {
            return new SystemEmail
            {
                Body = body,
                Subject = subject,
                To = to,
                ClientName = clientName
            };
        }

        private async Task<bool> SendEmailAsync(string body, string email, string clientName) =>
            await _emailService.SendEmailAsync(SetupEmail(body, "Confirm Email", email, clientName));
    }
}
