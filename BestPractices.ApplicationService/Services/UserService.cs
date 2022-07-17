using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Client;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.ApplicationService.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManagerService _tokenManagerService;

        public UserService(IUserRepository userRepository, ITokenManagerService tokenManagerService,
                           IValidate<User> validate, INotificationHandler notification)
                           : base(validate, notification)
        {
            _userRepository = userRepository;
            _tokenManagerService = tokenManagerService;
        }

        public async Task<bool> RegisterAsync(UserSaveRequest userSaveRequest)
        {
            var user = userSaveRequest.MapTo<UserSaveRequest, User>();

            if (!await ValidatedAsync(user))
                return false;
            
            AddEntitiesUser(user);

            return await CallRegisterAsync(user);
        }

        public async Task<BearerTokenResponse> LoginAsync(UserSaveRequest userSaveRequest)
        {
            var result = await _userRepository.LoginAsync(userSaveRequest.Email, userSaveRequest.Password);

            if (!result.Succeeded)
            {
                _notification.AddNotification("Login", EMessage.InvalidCredencials.Description());
                return null;
            }

            return await _tokenManagerService.GenerateAccessToken(userSaveRequest.Email);
        }

        public async Task<bool> UpdateAsync(UserUpdateRequest updateRequest)
        {
            var user = await FillUserUpdate(updateRequest);

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

        public async Task<List<UserResponseClient>> FindAllEntitiesAsync()
        {
            var users = await _userRepository.GetAllAsync(include: u => u.Include(u => u.Client).Include(u => u.ShoppingCarts));

            return users.MapTo<List<User>, List<UserResponseClient>>();
        }

        public async Task<PageList<UserResponseClient>> FindAllEntitiesWithPaginationAsync(PageParams pageParams)
        {
            var users = await _userRepository.FindAllWithPaginationAsync(pageParams, include: u => u.Include(u => u.Client).Include(u => u.ShoppingCarts));

            return users.MapTo<PageList<User>, PageList<UserResponseClient>>();
        }

        private async Task<bool> CallRegisterAsync(User user)
        {
            var result = await _userRepository.RegisterAsync(user);

            if (!result.Succeeded)
                AddIdentityErrors(result.Errors);

            return result.Succeeded;
        }

        private void AddEntitiesUser(User user)
        {
            user.Client = CreateNullClient();
            user.ShoppingCarts = new List<ShoppingCart>();
        }

        private Client CreateNullClient()
        {
            return new Client()
            {
                Name = "",
                LastName = "",
                BirthDate = DateTime.UtcNow,
                DocumentNumber = ""
            };
        }

        private void AddIdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
                _notification.AddNotification("Identity", error.Description);
        }

        private async Task<User> FillUserUpdate(UserUpdateRequest updateRequest)
        {
            var user = await _userRepository.FindByIdAsync(updateRequest.Id);
            user.Client = updateRequest.ClientUpdateRequest.MapTo<ClientUpdateRequest, Client>();
            user.ClientId = updateRequest.ClientUpdateRequest.Id;
            return user;
        }
    }
}
