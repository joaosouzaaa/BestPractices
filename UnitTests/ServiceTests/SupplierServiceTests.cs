using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Address;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Services;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Entities.EntityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.Builders.Helpers;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class SupplierServiceTests
    {
        Mock<ISupplierRepository> _repository;
        NotificationHandler _notification;
        SupplierValidation _validation;
        SupplierService _service;

        public SupplierServiceTests()
        {
            _repository = new Mock<ISupplierRepository>();
            _notification = new NotificationHandler();
            _validation = new SupplierValidation();
            _service = new SupplierService(_repository.Object, _validation, _notification);

            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTrue_HasNotificationFalse()
        {
            var id = 1;
            _repository.Setup(r => r.EntityExistAsync(id)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.DeleteAsync(id)).Returns(Task.FromResult(true));

            var serviceResult = await _service.DeleteAsync(id);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.DeleteAsync(id), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse_HasNotificationTrue()
        {
            var id = 1;
            _repository.Setup(r => r.EntityExistAsync(id)).Returns(Task.FromResult(false));
            _repository.Setup(r => r.DeleteAsync(id)).Returns(Task.FromResult(false));

            var serviceResult = await _service.DeleteAsync(id);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.DeleteAsync(id), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }

        [Fact]
        public async Task FindAllEntitiesAsync_ReturnsEntities()
        {
            var supplierList = new List<Supplier>
            {
                SupplierBuilder.NewObject().DomainBuild()
            };
            _repository.Setup(r => r.GetAll(It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>())).Returns(Task.FromResult(supplierList));

            var serviceResult = await _service.FindAllEntitiesAsync();

            _repository.Verify(r => r.GetAll(It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>()), Times.Once());
            Assert.NotNull(_repository.Object.GetAll(It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>()));
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesAsync_ReturnsNull()
        {
            _repository.Setup(r => r.GetAll(It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>())).Returns(Task.FromResult<List<Supplier>>(null));

            var serviceResult = await _service.FindAllEntitiesAsync();

            _repository.Verify(r => r.GetAll(It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>()), Times.Once());
            Assert.Empty(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesWithPaginationAsync_ReturnsEntities()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            var supplierList = new List<Supplier>
            {
                SupplierBuilder.NewObject().DomainBuild()
            };
            var supplierPageList = Utils.PageListBuilder<Supplier>(supplierList);
            _repository.Setup(r => r.FindAllWithPagination(pageParams, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>())).Returns(Task.FromResult(supplierPageList));

            var serviceResult = await _service.FindAllEntitiesWithPaginationAsync(pageParams);

            _repository.Verify(r => r.FindAllWithPagination(pageParams, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>()), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesWithPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.FindAllWithPagination(pageParams, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>())).Returns(Task.FromResult<PageList<Supplier>>(null));

            var serviceResult = await _service.FindAllEntitiesWithPaginationAsync(pageParams);

            _repository.Verify(r => r.FindAllWithPagination(pageParams, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>()), Times.Once());
            Assert.Null(serviceResult);
        }

        [Fact]
        public async Task FindByIdAsync_ReturnsEntity()
        {
            var id = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetById(id, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false)).Returns(Task.FromResult(supplier));

            var serviceResult = await _service.FindByIdAsync(id);

            _repository.Verify(r => r.GetById(id, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindByIdAsync_ReturnsNull()
        {
            var id = 1;
            _repository.Setup(r => r.GetById(id, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false)).Returns(Task.FromResult<Supplier>(null));

            var serviceResult = await _service.FindByIdAsync(id);

            _repository.Verify(r => r.GetById(id, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false), Times.Once());
            Assert.Null(serviceResult);
        }

        [Fact]
        public async Task SaveAsync_ReturnsTrue_HasNotificationFalse()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            _repository.Setup(r => r.SaveAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.SaveAsync(supplierSaveRequest);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.SaveAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }

        [Fact]
        public async Task SaveAsync_ReturnsFalse_HasNotificationTrue()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().WithCnpj("").SaveRequestBuild();
            _repository.Setup(r => r.SaveAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(false));

            var serviceResult = await _service.SaveAsync(supplierSaveRequest);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.SaveAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue_HasNotificationFalse()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().UpdateRequesBuild();
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.UpdateAsync(supplierUpdateRequest);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse_HasNotificationTrue()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().WithCnpj("").UpdateRequesBuild();
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(false));

            var serviceResult = await _service.UpdateAsync(supplierUpdateRequest);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsTrue_HasNotificationFalse()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            var product = ProductBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.EntityExistAsync(supplierId)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.GenericExistAsync<Product>(productId)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.GetById(supplierId, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false)).Returns(Task.FromResult(supplier));
            _repository.Setup(r => r.FindByGenericAsync<Product>(productId, It.IsAny<Func<IQueryable<Product>, IIncludableQueryable<Product, object>>>(), false)).Returns(Task.FromResult(product));
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));
            
            var serviceResult = await _service.AddProductAsync(supplierId, productId);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse_HasNotificationTrue_EntityDoesNotExist()
        {
            var supplierId = 1;
            var productId = 1;
            _repository.Setup(r => r.EntityExistAsync(supplierId)).Returns(Task.FromResult(false));
            _repository.Setup(r => r.GenericExistAsync<Product>(productId)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(false));

            var serviceResult = await _service.AddProductAsync(supplierId, productId);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse_HasNotificationTrue_ProductDoesNotExist()
        {
            var supplierId = 1;
            var productId = 1;
            _repository.Setup(r => r.EntityExistAsync(supplierId)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.GenericExistAsync<Product>(productId)).Returns(Task.FromResult(false));
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(false));

            var serviceResult = await _service.AddProductAsync(supplierId, productId);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsTrue_HasNotificationFalse()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.EntityExistAsync(supplierId)).Returns(Task.FromResult(true));
            _repository.Setup(r => r.GetById(supplierId, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false)).Returns(Task.FromResult(supplier));
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.RemoveProductAsync(supplierId, productId);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsFalse_HasNotificationTrue_EntityDoesNotExist()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.EntityExistAsync(supplierId)).Returns(Task.FromResult(false));
            _repository.Setup(r => r.GetById(supplierId, It.IsAny<Func<IQueryable<Supplier>, IIncludableQueryable<Supplier, object>>>(), false)).Returns(Task.FromResult(supplier));
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.RemoveProductAsync(supplierId, productId);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
            Assert.True(hasNotification);
        }
    }
}
