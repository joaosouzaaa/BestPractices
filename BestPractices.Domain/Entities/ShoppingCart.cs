using BestPractices.Domain.Entities.EntityBase;

namespace BestPractices.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int TotalItens { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> Products { get; set; }
    }
}
