using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.Services
{
    public class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
                                   IValidate<ShoppingCart> validate, INotificationHandler notification)
                                   : base(validate, notification)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartResponse>> FindAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PageList<ShoppingCartResponse>> FindAllEntitiesWithPaginationAsync(PageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartResponse> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(ShoppingCartSaveRequest clientSaveRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ShoppingCartUpdateRequest clientUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
