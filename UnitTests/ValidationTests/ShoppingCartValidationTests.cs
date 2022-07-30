using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class ShoppingCartValidationTests
    {
        ShoppingCartValidation _validate;

        public ShoppingCartValidationTests()
        {
            _validate = new ShoppingCartValidation();
        }

        [Fact]
        public async Task ShoppingCartValidation_ValidProperties_ReturnsTrue()
        {
            var shoppingCart = ShoppingCartBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(shoppingCart);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public async Task ShoppingCartValidation_InvalidTotalItens_ReturnsFalse(int totalItens)
        {
            var product = ShoppingCartBuilder.NewObject().WithTotalItens(totalItens).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public async Task ShoppingCartValidation_InvalidTotalAmount_ReturnsFalse(decimal totalAmount)
        {
            var product = ShoppingCartBuilder.NewObject().WithTotalAmount(totalAmount).DomainBuild();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.Valid);
        }
    }
}
