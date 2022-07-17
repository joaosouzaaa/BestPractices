using BestPractices.Domain.Entities.EntityBase;

namespace BestPractices.Domain.Entities
{
    public class FileImage : BaseEntity
    {
        public byte[] ImageBytes { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }
}
