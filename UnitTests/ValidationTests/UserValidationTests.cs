using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class UserValidationTests
    {
        UserValidation _validate;

        public UserValidationTests()
        {
            _validate = new UserValidation();
        }

        [Fact]
        public async Task UserValidation_ValidProperties_ReturnsTrue()
        {
            var user = UserBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(user);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("joao")]
        [InlineData("aaaaaaaaaaaaaaaa")]
        public async Task UserValidation_InvalidEmail_ReturnsFalse(string email)
        {
            var user = UserBuilder.NewObject().WithEmail(email).DomainBuild();

            var response = await _validate.ValidateAsync(user);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("aaaaaa")]
        [InlineData("1555")]
        [InlineData("1555Joao")]
        public async Task UserValidation_InvalidPassword_ReturnsFalse(string password)
        {
            var user = UserBuilder.NewObject().WithPassword(password).DomainBuild();

            var response = await _validate.ValidateAsync(user);

            Assert.False(response.Valid);
        }
    }
}
