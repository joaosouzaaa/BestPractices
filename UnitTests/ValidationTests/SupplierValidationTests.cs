using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class SupplierValidationTests
    {
        SupplierValidation _validate;

        public SupplierValidationTests()
        {
            _validate = new SupplierValidation();
        }

        [Fact]
        public async Task SupplierValidation_ValidProperties_ReturnsTrue()
        {
            var supplier = SupplierBuilder.NewObject().DomainBuild();

            var response = await _validate.ValidateAsync(supplier);

            Assert.True(response.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task SupplierValidation_InvalidCNPJ_ReturnsFalse(string cnpj)
        {
            var supplier = SupplierBuilder.NewObject().WithCnpj(cnpj).DomainBuild();

            var response = await _validate.ValidateAsync(supplier);

            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task SupplierValidation_InvalidCompanyName_ReturnsFalse(string companyName)
        {
            var supplier = SupplierBuilder.NewObject().WithCompanyName(companyName).DomainBuild();

            var response = await _validate.ValidateAsync(supplier);

            Assert.False(response.Valid);
        }
    }
}
