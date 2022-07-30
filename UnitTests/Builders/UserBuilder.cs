using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class UserBuilder
    {
        private string _email = "joaoa@gmail.com";
        private string _phoneNumber = "41996583001";
        private string _password = "123@Joao";

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
                Id = Guid.NewGuid().ToString(),
                PhoneNumber = _phoneNumber,
                PasswordHash = _password,
                ShoppingCarts = shoppingCartList,
                UserName = _email
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
