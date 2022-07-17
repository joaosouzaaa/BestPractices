using BestPractices.ApplicationService.Interfaces.BaseService;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IShoppingCartService : IBaseService<ShoppingCartSaveRequest, ShoppingCartUpdateRequest>
    {
        Task<ShoppingCartResponse> FindByIdAsync(int id);
        Task<bool> AddProductAsync(int shoppingCartId, int productId);
        Task<bool> RemoveProductAsync(int shoppingCartId, int productId);
    }
}
