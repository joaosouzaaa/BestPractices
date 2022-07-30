using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class ProductValidationTests
    {
        ProductValidation _validate;

        public ProductValidationTests()
        {
            _validate = new ProductValidation();
        }

        [Fact]
        public async Task ProductValidation_ValidProperties_ReturnsTrue()
        {
            var product = ProductBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task ProductValidation_InvalidProductName_ReturnsFalse(string productName)
        {
            var product = ProductBuilder.NewObject().WithProductName(productName).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public async Task ProductValidation_InvalidPrice_ReturnsFalse(decimal price)
        {
            var product = ProductBuilder.NewObject().WithPrice(price).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task ProductValidation_InvalidBrand_ReturnsFalse(string brand)
        {
            var product = ProductBuilder.NewObject().WithBrand(brand).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("")]
        public async Task ProductValidation_InvalidDescription_ReturnsFalse(string description)
        {
            var product = ProductBuilder.NewObject().WithDescription(description).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public async Task ProductValidation_InvalidTransportationPrice_ReturnsFalse(decimal transportationPrice)
        {
            var product = ProductBuilder.NewObject().WithTransportationPrice(transportationPrice).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }
    }
}
