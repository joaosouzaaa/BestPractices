using BestPractices.Domain.Entities.EntityBase;

namespace BestPractices.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int TotalItens { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Finished { get; set; } = false;

        public string UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }

        //public ShoppingCart()
        //{
        //    TotalItens = Products.Count;
        //    TotalAmount = 0;
        //    foreach (var product in Products)
        //    {
        //        TotalAmount += product.Price;
        //    }
        //}
    }
}
