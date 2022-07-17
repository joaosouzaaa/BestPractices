using BestPractices.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BestPractices.Business.Extensions
{
    public static class FileExtension
    {
        public static byte[] ImageToBytes(this IFormFile image)
        {
            var extensionList = new List<string>()
            {
                ".jpeg",
                ".jpg",
                ".png",
                ".jfif",
                ".JPEG",
                ".JPG",
                ".PNG",
                ".JFIF"
            };

            if (image.Length > 0)
            {
                var imageExtension = Path.GetExtension(image.FileName);

                if (!extensionList.Contains(imageExtension))
                    return null;

                using (var stream = new MemoryStream())
                {
                    image.CopyTo(stream);

                    return stream.ToArray();
                }
            }

            return null;
        }

        public static FileImage BuildFileImage(this IFormFile image)
        {
            return new FileImage
            {
                ImageBytes = image.ImageToBytes(),
                FileName = image.FileName,
                FileExtension = image.ContentType,
            };
        }
    }
}
