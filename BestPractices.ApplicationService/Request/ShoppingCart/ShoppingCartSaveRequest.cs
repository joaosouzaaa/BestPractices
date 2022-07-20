namespace BestPractices.ApplicationService.Request.ShoppingCart
{
    public class ShoppingCartSaveRequest
    {
        public string UserId { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}
