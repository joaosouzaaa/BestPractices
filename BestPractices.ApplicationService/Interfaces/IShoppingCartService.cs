using BestPractices.ApplicationService.Interfaces.BaseService;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IShoppingCartService : IBaseQueryService<ShoppingCartSaveRequest, ShoppingCartUpdateRequest, ShoppingCartResponse>
    {
    }
}
