using BestPractices.ApplicationService.Request.Enums;
using Microsoft.AspNetCore.Http;

namespace BestPractices.ApplicationService.Request.Product
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public ECategoryRequest Category { get; set; }
        public string Description { get; set; }
        public decimal TransportationPrice { get; set; }
        public IFormFile? Image { get; set; }
    }
}
