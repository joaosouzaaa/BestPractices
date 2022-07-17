namespace BestPractices.ApplicationService.Request.ShoppingCart
{
    public class ShoppingCartSaveRequest
    {
        public int TotalItens { get; set; }
        public int TotalAmount { get; set; }

        public string UserId { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}
