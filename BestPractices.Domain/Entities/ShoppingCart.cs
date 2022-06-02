namespace BestPractices.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int TotalItens { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> Products { get; set; }
    }
}
