namespace BestPractices.ApplicationService.Request.ShoppingCart
{
    public class ShoppingCartUpdateRequest
    {
        public int Id { get; set; }
        public int TotalItens { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
