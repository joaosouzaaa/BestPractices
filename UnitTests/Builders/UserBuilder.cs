using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class UserBuilder
    {
        private string _email = "joaoa@gmail.com";
        private string _phoneNumber = "41996583001";
        private string _password = "123@Joao";
        private string _id = Guid.NewGuid().ToString();

        public static UserBuilder NewObject()
        {
            return new UserBuilder();
        }

        public User DomainBuild()
        {
            var client = ClientBuilder.NewObject().DomainBuild();
            var shoppingCartList = new List<ShoppingCart>();
            shoppingCartList.Add(ShoppingCartBuilder.NewObject().DomainBuild());
            return new User
            {
                AccessFailedCount = 0,
                Client = client,
                Email = _email,
                EmailConfirmed = true,
                Id = _id,
                PhoneNumber = _phoneNumber,
                PasswordHash = _password,
                ShoppingCarts = shoppingCartList,
                UserName = _email
            };
        }

        public UserSaveRequest SaveRequestBuild()
        {
            return new UserSaveRequest
            {
                Email = _email,
                Password = _password
            };
        }

        public UserUpdateRequest UpdateRequestBuild()
        {
            var clientUpdateRequest = ClientBuilder.NewObject().UpdateRequestBuild();
            return new UserUpdateRequest
            {
                Id = _id,
                ClientUpdateRequest = clientUpdateRequest
            };
        }

        public UserResponse ResponseBuild()
        {
            return new UserResponse
            {
                Email = _email,
                Password = _password
            };
        }

        public UserResponseClient ResponseClientBuild()
        {
            var clientResponse = ClientBuilder.NewObject().ResponseBuild();
            return new UserResponseClient
            {
                Email = _email,
                Id = _id,
                ClientResponse = clientResponse
            };
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }
    }
}
