using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Response.FileImage;
using BestPractices.Domain.Entities;
using ExpectedObjects;

namespace UnitTests.AutoMapperTests
{
    public class FileImageAutoMapperTests
    {
        public FileImage FileImage = FileImageBuilder.NewObject().DomainBuild();

        public FileImageAutoMapperTests()
        {
            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public void FileImage_To_FileImageResponse() =>
            FileImage.MapTo<FileImage, FileImageResponse>().ToExpectedObject().ShouldMatch(FileImage);
    }
}
