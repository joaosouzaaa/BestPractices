using BestPractices.ApplicationService.Response.FileImage;
using BestPractices.Domain.Entities;

namespace Builders
{
    public class FileImageBuilder
    {
        private string _fileName = "file name";
        private string _fileExtension = "image/pdf";
        private byte[] _imageBytes = { 0x32, 0x00, 0x1E, 0x00 };

        public static FileImageBuilder NewObject()
        {
            return new FileImageBuilder();
        }

        public FileImage DomainBuild()
        {
            return new FileImage
            {
                FileName = _fileName,
                FileExtension = _fileExtension,
                ImageBytes = _imageBytes,
            };
        }

        public FileImageResponse ResponseBuild()
        {
            return new FileImageResponse
            {
                FileExtension = _fileExtension,
                FileName = _fileName,
                Id = 1,
                ImageBytes = _imageBytes
            };
        }

        public FileImageBuilder WithFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }

        public FileImageBuilder WithFileExtension(string fileExtension)
        {
            _fileExtension = fileExtension;
            return this;
        }

        public FileImageBuilder WithImageBytes(byte[] imageBytes)
        {
            _imageBytes = imageBytes;
            return this;
        }
    }
}
