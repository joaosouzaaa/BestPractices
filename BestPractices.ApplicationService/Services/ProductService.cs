using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;
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
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository,
                              IValidate<Product> validate, INotificationHandler notification) 
                              : base(validate, notification)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _productRepository.EntityExistAsync(id))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Product")));

            return await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductResponse>> FindAllEntitiesAsync()
        {
            var products = await _productRepository.GetAll(include: p => p.Include(p => p.FileImage).Include(p => p.Supplier));

            return products.MapTo<List<Product>, List<ProductResponse>>();
        }

        public async Task<PageList<ProductResponse>> FindAllEntitiesWithPaginationAsync(PageParams pageParams)
        {
            var products = await _productRepository.FindAllWithPagination(pageParams, include: p => p.Include(p => p.FileImage).Include(p => p.Supplier));

            return products.MapTo<PageList<Product>, PageList<ProductResponse>>();
        }

        public async Task<ProductResponse> FindByIdAsync(int id)
        {
            var product = await _productRepository.GetById(id, include: p => p.Include(p => p.FileImage).Include(p => p.Supplier));

            return product.MapTo<Product, ProductResponse>();
        }

        public async Task<bool> SaveAsync(ProductSaveRequest saveRequest)
        {
            var product = saveRequest.MapTo<ProductSaveRequest, Product>();
            
            if(saveRequest.Image != null)
                product.FileImage = saveRequest.Image.BuildFileImage();

            if (!await ValidatedAsync(product))
                return false;
            else
                return await _productRepository.SaveAsync(product);
        }

        public async Task<bool> UpdateAsync(ProductUpdateRequest updateRequest)
        {
            var product = updateRequest.MapTo<ProductUpdateRequest, Product>();
            
            if (updateRequest.Image != null)
                product.FileImage = updateRequest.Image.BuildFileImage();

            if (!await ValidatedAsync(product))
                return false;
            else
                return await _productRepository.UpdateAsync(product);
        }
    }
}
