using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Services;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;
using BestPractices.Domain.Entities;
using Builders.Helpers;

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
        public async Task DeleteAsync_ReturnsTrue()
        {
            var id = 1;
            _repository.Setup(r => r.EntityExistAsync(id)).ReturnsAsync(true);
            _repository.Setup(r => r.DeleteAsync(id)).ReturnsAsync(true);

            var serviceResult = await _service.DeleteAsync(id);

            _repository.Verify(r => r.EntityExistAsync(id), Times.Once());
            _repository.Verify(r => r.DeleteAsync(id), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task DeleteAsync_EntityDoesNotExist_ReturnsFalse()
        {
            var id = 1;
            _repository.Setup(r => r.EntityExistAsync(id)).ReturnsAsync(false);

            var serviceResult = await _service.DeleteAsync(id);

            _repository.Verify(r => r.EntityExistAsync(id), Times.Once());
            _repository.Verify(r => r.DeleteAsync(id), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesAsync_ReturnsEntities()
        {
            var supplierList = new List<Supplier>
            {
                SupplierBuilder.NewObject().DomainBuild()
            };
            _repository.Setup(r => r.GetAll(Utils.BuildIQueryableIncludeFunc<Supplier>())).ReturnsAsync(supplierList);

            var serviceResult = await _service.FindAllEntitiesAsync();

            _repository.Verify(r => r.GetAll(Utils.BuildIQueryableIncludeFunc<Supplier>()), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesAsync_ReturnsNull()
        {
            _repository.Setup(r => r.GetAll(Utils.BuildIQueryableIncludeFunc<Supplier>()));

            var serviceResult = await _service.FindAllEntitiesAsync();

            _repository.Verify(r => r.GetAll(Utils.BuildIQueryableIncludeFunc<Supplier>()), Times.Once());
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
            var supplierPageList = Utils.PageListBuilder(supplierList);
            _repository.Setup(r => r.FindAllWithPagination(pageParams, Utils.BuildIQueryableIncludeFunc<Supplier>())).ReturnsAsync(supplierPageList);

            var serviceResult = await _service.FindAllEntitiesWithPaginationAsync(pageParams);

            _repository.Verify(r => r.FindAllWithPagination(pageParams, Utils.BuildIQueryableIncludeFunc<Supplier>()), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindAllEntitiesWithPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.FindAllWithPagination(pageParams, Utils.BuildIQueryableIncludeFunc<Supplier>()));

            var serviceResult = await _service.FindAllEntitiesWithPaginationAsync(pageParams);

            _repository.Verify(r => r.FindAllWithPagination(pageParams, Utils.BuildIQueryableIncludeFunc<Supplier>()), Times.Once());
            Assert.Null(serviceResult);
        }

        [Fact]
        public async Task FindByIdAsync_ReturnsEntity()
        {
            var id = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetById(id, Utils.BuildIQueryableIncludeFunc<Supplier>(), false)).ReturnsAsync(supplier);

            var serviceResult = await _service.FindByIdAsync(id);

            _repository.Verify(r => r.GetById(id, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            Assert.NotNull(serviceResult);
        }

        [Fact]
        public async Task FindByIdAsync_ReturnsNull()
        {
            var id = 1;
            _repository.Setup(r => r.GetById(id, Utils.BuildIQueryableIncludeFunc<Supplier>(), false));

            var serviceResult = await _service.FindByIdAsync(id);

            _repository.Verify(r => r.GetById(id, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            Assert.Null(serviceResult);
        }

        [Fact]
        public async Task SaveAsync_ReturnsTrue()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            _repository.Setup(r => r.SaveAsync(It.IsAny<Supplier>())).ReturnsAsync(true);

            var serviceResult = await _service.SaveAsync(supplierSaveRequest);

            _repository.Verify(r => r.SaveAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task SaveAsync_EntityInvalid_ReturnsFalse()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().WithCnpj("").SaveRequestBuild();

            var serviceResult = await _service.SaveAsync(supplierSaveRequest);

            _repository.Verify(r => r.SaveAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().UpdateRequesBuild();
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).ReturnsAsync(true);

            var serviceResult = await _service.UpdateAsync(supplierUpdateRequest);

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task UpdateAsync_EntityInvalid_ReturnsFalse()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().WithCnpj("").UpdateRequesBuild();

            var serviceResult = await _service.UpdateAsync(supplierUpdateRequest);

            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsTrue()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            var product = ProductBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false)).ReturnsAsync(supplier);
            _repository.Setup(r => r.FindByGenericAsync(productId, Utils.BuildIQueryableIncludeFunc<Product>(), false)).ReturnsAsync(product);
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).ReturnsAsync(true);
            
            var serviceResult = await _service.AddProductAsync(supplierId, productId);

            _repository.Verify(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            _repository.Verify(r => r.FindByGenericAsync(productId, Utils.BuildIQueryableIncludeFunc<Product>(), false), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task AddProductAsync__ReturnsFalse()
        {
            var supplierId = 1;
            var productId = 1;
            _repository.Setup(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false));

            var serviceResult = await _service.AddProductAsync(supplierId, productId);

            _repository.Verify(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            _repository.Verify(r => r.FindByGenericAsync(productId, Utils.BuildIQueryableIncludeFunc<Product>(), false), Times.Never());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task AddProductAsync_ProductDoesNotExist_ReturnsFalse()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false)).ReturnsAsync(supplier);
            _repository.Setup(r => r.FindByGenericAsync(productId, Utils.BuildIQueryableIncludeFunc<Product>(), false));

            var serviceResult = await _service.AddProductAsync(supplierId, productId);

            _repository.Verify(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            _repository.Verify(r => r.FindByGenericAsync(productId, Utils.BuildIQueryableIncludeFunc<Product>(), false), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Never());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsTrue()
        {
            var supplierId = 1;
            var productId = 1;
            var supplier = SupplierBuilder.NewObject().DomainBuild();
            _repository.Setup(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false)).ReturnsAsync(supplier);
            _repository.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).ReturnsAsync(true);

            var serviceResult = await _service.RemoveProductAsync(supplierId, productId);

            _repository.Verify(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task RemoveProductAsync_EntityDoesNotExist_ReturnsFalse()
        {
            var supplierId = 1;
            var productId = 1;
            _repository.Setup(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false));

            var serviceResult = await _service.RemoveProductAsync(supplierId, productId);

            _repository.Verify(r => r.GetById(supplierId, Utils.BuildIQueryableIncludeFunc<Supplier>(), false), Times.Once());
            _repository.Verify(r => r.UpdateAsync(It.IsAny<Supplier>()), Times.Exactly(0));
            Assert.False(serviceResult);
        }
    }
}
