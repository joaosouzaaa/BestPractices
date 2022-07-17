using BestPractices.ApplicationService.Response.FileImage;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Domain.Enums;

namespace BestPractices.ApplicationService.Response.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public ECategory Category { get; set; }
        public string Description { get; set; }
        public decimal TransportationPrice { get; set; }

        public FileImageResponse? FileImageResponse { get; set; }
        public SupplierResponse SupplierResponse { get; set; }
    }
}
