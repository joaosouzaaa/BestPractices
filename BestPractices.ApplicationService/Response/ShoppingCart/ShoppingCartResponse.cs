using BestPractices.ApplicationService.Response.Product;
using BestPractices.ApplicationService.Response.User;

namespace BestPractices.ApplicationService.Response.ShoppingCart
{
    public class ShoppingCartResponse
    {
        public int Id { get; set; }
        public int TotalItens { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Finished { get; set; }

        public UserResponseClient UserResponseClient { get; set; }
        public List<ProductResponse> ProductsResponse { get; set; }
    }
}
