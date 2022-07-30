using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class ClientValidationTests
    {
        ClientValidation _validate;

        public ClientValidationTests()
        {
            _validate = new ClientValidation();
        }

        [Fact]
        public async Task ClientValidation_ValidProperties_ReturnsTrue()
        {
            var client = ClientBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task ClientValidation_InvalidName_ReturnsFalse(string name)
        {
            var client = ClientBuilder.NewObject().WithName(name).DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task ClientValidation_InvalidLastName_ReturnsFalse(string lastName)
        {
            var client = ClientBuilder.NewObject().WithLastName(lastName).DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.False(response.Valid);
        }

        [Fact]
        public async Task ClientValidation_InvalidBirthDate_DateExceeded_ReturnsFalse()
        {
            var birthDate = new DateTime(2033, 01, 03);
            var client = ClientBuilder.NewObject().WithBirthDate(birthDate).DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.False(response.Valid);
        }

        [Fact]
        public async Task ClientValidation_InvalidBirthDate_ReturnsFalse()
        {
            var birthDate = new DateTime(1800, 01, 03);
            var client = ClientBuilder.NewObject().WithBirthDate(birthDate).DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("")]
        public async Task ClientValidation_InvalidDocumentNumber_ReturnsFalse(string documentNumber)
        {
            var client = ClientBuilder.NewObject().WithDocumentNumber(documentNumber).DomainBuild();

            var response = await _validate.ValidateAsync(client);

            Assert.False(response.Valid);
        }
    }
}
