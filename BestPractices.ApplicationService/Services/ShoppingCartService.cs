using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _shoppingCartRepository.EntityExistAsync(id))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Shopping Cart")));

            return await _shoppingCartRepository.DeleteAsync(id);
        }

        public async Task<ShoppingCartResponse> FindByIdAsync(int id)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCart(id);

            return shoppingCart.MapTo<ShoppingCart, ShoppingCartResponse>();
        }

        public async Task<bool> SaveAsync(ShoppingCartSaveRequest saveRequest)
        {
           // if (saveRequest.ProductsIds.Count == 0)
             //   return _notification.AddNotification(new DomainNotification("Products", "Add at least one item"));

            var shoppingCart = saveRequest.MapTo<ShoppingCartSaveRequest, ShoppingCart>();

            //if (!await ValidatedAsync(shoppingCart))
              //  return false;
            
            return await _shoppingCartRepository.SaveAsync(shoppingCart);
        }

        public async Task<bool> UpdateAsync(ShoppingCartUpdateRequest updateRequest)
        {
            var shoppingCart = updateRequest.MapTo<ShoppingCartUpdateRequest, ShoppingCart>();

            if (!await ValidatedAsync(shoppingCart))
                return false;
            else
                return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        }

        public async Task<bool> AddProductAsync(int shoppingCartId, int productId)
        {
            if (!await _shoppingCartRepository.EntityExistAsync(shoppingCartId))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Shopping Cart")));

            var shoppingCart = await _shoppingCartRepository.GetShoppingCart(shoppingCartId);
            var product = await _shoppingCartRepository.FindByGenericAsync<Product>(productId, include: p => p.Include(p => p.ShoppingCart));

            shoppingCart.Products.Add(product);

            return await _shoppingCartRepository.UpdateAsync(shoppingCart);

        }

        public async Task<bool> RemoveProductAsync(int shoppingCartId, int productId)
        {
            if (!await _shoppingCartRepository.EntityExistAsync(shoppingCartId))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Shopping Cart")));

            var shoppingCart = await _shoppingCartRepository.GetShoppingCart(shoppingCartId);
            var product = shoppingCart.Products.Find(p => p.Id == productId);

            shoppingCart.Products.Remove(product);

            return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        }
    }
}
