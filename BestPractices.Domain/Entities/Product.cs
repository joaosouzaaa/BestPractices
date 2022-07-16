using BestPractices.Domain.Entities.EntityBase;
using BestPractices.Domain.Enums;

namespace BestPractices.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public ECategory Category{ get; set; }
        public string Description { get; set; }
        public byte[] ProductImage { get; set; }
        public string ProductImageExtension { get; set; }
        public decimal TransportationPrice { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
