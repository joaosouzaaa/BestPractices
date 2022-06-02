using BestPractices.Domain.Enums;

namespace BestPractices.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public ECategory Category{ get; set; }
        public string Description { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
