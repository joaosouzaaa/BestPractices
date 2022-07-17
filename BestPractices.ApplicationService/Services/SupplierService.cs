using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
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
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository,
                               IValidate<Supplier> validate, INotificationHandler notification) 
                               : base(validate, notification)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _supplierRepository.EntityExistAsync(id))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Supplier")));

            return await _supplierRepository.DeleteAsync(id);
        }

        public async Task<List<SupplierResponse>> FindAllEntitiesAsync()
        {
            var suppliers = await _supplierRepository.GetAll(include: s => s.Include(s => s.CompanyAddress).Include(s => s.Products));

            return suppliers.MapTo<List<Supplier>, List<SupplierResponse>>();
        }

        public async Task<PageList<SupplierResponse>> FindAllEntitiesWithPaginationAsync(PageParams pageParams)
        {
            var suppliers = await _supplierRepository.FindAllWithPagination(pageParams, include: s => s.Include(s => s.CompanyAddress).Include(s => s.Products));

            return suppliers.MapTo<PageList<Supplier>, PageList<SupplierResponse>>();
        }

        public async Task<SupplierResponse> FindByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetById(id, include: s => s.Include(s => s.CompanyAddress).Include(s => s.Products));

            return supplier.MapTo<Supplier, SupplierResponse>();
        }

        public async Task<bool> SaveAsync(SupplierSaveRequest saveRequest)
        {
            var supplier = saveRequest.MapTo<SupplierSaveRequest, Supplier>();

            if (!await ValidatedAsync(supplier))
                return false;
            else
                return await _supplierRepository.SaveAsync(supplier);
        }

        public async Task<bool> UpdateAsync(SupplierUpdateRequest updateRequest)
        {
            var supplier = updateRequest.MapTo<SupplierUpdateRequest, Supplier>();

            if (!await ValidatedAsync(supplier))
                return false;
            else
                return await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task<bool> AddProductAsync(int supplierId, int productId)
        {
            if (!await _supplierRepository.EntityExistAsync(supplierId))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Supplier")));

            var supplier = await _supplierRepository.GetById(supplierId, include: s => s.Include(s => s.Products));
            var product = await _supplierRepository.FindByGenericAsync<Product>(productId, include: p => p.Include(p => p.Supplier));
            
            supplier.Products.Add(product);

            return await _supplierRepository.UpdateAsync(supplier);

        }

        public async Task<bool> RemoveProductAsync(int supplierId, int productId)
        {
            if (!await _supplierRepository.EntityExistAsync(supplierId))
                return _notification.AddNotification(new DomainNotification("Id", EMessage.NotFound.Description().FormatTo("Supplier")));

            var supplier = await _supplierRepository.GetById(supplierId, include: s => s.Include(s => s.Products));
            var product = supplier.Products.Find(p => p.Id == productId);

            supplier.Products.Remove(product);

            return await _supplierRepository.UpdateAsync(supplier);
        }
    }
}
