namespace BestPractices.ApplicationService.Response.FileImage
{
    public class FileImageResponse
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }
}
