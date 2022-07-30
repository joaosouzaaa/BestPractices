using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class AddressValidationTests
    {
        AddressValidation _validate;

        public AddressValidationTests()
        {
            _validate = new AddressValidation();
        }

        [Fact]
        public async Task AddressValidation_ValidProperties_ReturnsTrue()
        {
            var address = AddressBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("baaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        public async Task AddressValidation_InvalidZipCode_ReturnsFalse(string zipCode)
        {
            var address = AddressBuilder.NewObject().WithZipCode(zipCode).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("baaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        public async Task AddressValidation_InvalidCity_ReturnsFalse(string city)
        {
            var address = AddressBuilder.NewObject().WithCity(city).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("baaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        public async Task AddressValidation_InvalidStreet_ReturnsFalse(string street)
        {
            var address = AddressBuilder.NewObject().WithStreet(street).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aaaaa")]
        [InlineData("")]
        public async Task AddressValidation_InvalidState_ReturnsFalse(string state)
        {
            var address = AddressBuilder.NewObject().WithState(state).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        public async Task AddressValidation_InvalidNumber_ReturnsFalse(string number)
        {
            var address = AddressBuilder.NewObject().WithNumber(number).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("baaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task AddressValidation_InvalidComplement_ReturnsFalse(string complement)
        {
            var address = AddressBuilder.NewObject().WithComplement(complement).DomainBuild();

            var response = await _validate.ValidateAsync(address);

            Assert.False(response.Valid);
        }
    }
}
