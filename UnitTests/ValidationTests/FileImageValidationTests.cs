using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;

namespace UnitTests.ValidationTests
{
    public class FileImageValidationTests
    {
        FileImageValidation _validate;

        public FileImageValidationTests()
        {
            _validate = new FileImageValidation();
        }

        [Fact]
        public async Task ValidateFileImage_Valid_True()
        {
            var fileImage = FileImageBuilder.NewObject().DomainBuild();

            var validationResponse = await _validate.ValidateAsync(fileImage);

            Assert.True(validationResponse.Valid);
        }

        [Theory]
        [InlineData(null)]
        public async Task ValidateFileImage_NullImageBytes_ReturnFalse(byte[] imageBytes)
        {
            var fileImage = FileImageBuilder.NewObject().WithImageBytes(imageBytes).DomainBuild();

            var validationResponse = await _validate.ValidateAsync(fileImage);

            Assert.False(validationResponse.Valid);
        }

        [Theory]
        [InlineData("dd")]
        [InlineData("dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd")]
        public async Task ValidateFileImage_InvalidFileName_ReturnFalse(string fileName)
        {
            var fileImage = FileImageBuilder.NewObject().WithFileName(fileName).DomainBuild();

            var validationResponse = await _validate.ValidateAsync(fileImage);

            Assert.False(validationResponse.Valid);
        }

        [Theory]
        [InlineData("dd")]
        [InlineData("dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd")]
        public async Task ValidateFileImage_InvalidFileExtension_ReturnFalse(string fileExtension)
        {
            var fileImage = FileImageBuilder.NewObject().WithFileExtension(fileExtension).DomainBuild();

            var validationResponse = await _validate.ValidateAsync(fileImage);

            Assert.False(validationResponse.Valid);
        }
    }
}
