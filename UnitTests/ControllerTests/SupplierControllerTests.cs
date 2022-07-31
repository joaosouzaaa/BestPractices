using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Business.Settings.PaginationSettings;
using UnitTests.Builders.Helpers;

namespace UnitTests.ControllerTests
{
    public class SupplierControllerTests
    {
        Mock<ISupplierService> _service;
        SupplierController _controller;

        public SupplierControllerTests()
        {
            _service = new Mock<ISupplierService>();
            _controller = new SupplierController(_service.Object);
        }

        [Fact]
        public async Task AddSupplierAsync_ReturnsTrue()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(supplierSaveRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.AddSupplierAsync(supplierSaveRequest);

            _service.Verify(s => s.SaveAsync(supplierSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddSupplierAsync_ReturnsFalse()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(supplierSaveRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.AddSupplierAsync(supplierSaveRequest);

            _service.Verify(s => s.SaveAsync(supplierSaveRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task UpdateSupplierAsync_ReturnsTrue()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().UpdateRequesBuild();
            _service.Setup(s => s.UpdateAsync(supplierUpdateRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.UpdateSupplierAsync(supplierUpdateRequest);

            _service.Verify(s => s.UpdateAsync(supplierUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateSupplierAsync_ReturnsFalse()
        {
            var supplierUpdateRequest = SupplierBuilder.NewObject().UpdateRequesBuild();
            _service.Setup(s => s.UpdateAsync(supplierUpdateRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.UpdateSupplierAsync(supplierUpdateRequest);

            _service.Verify(s => s.UpdateAsync(supplierUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task DeleteSupplierAsync_ReturnsTrue()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.DeleteSupplierAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteSupplierAsync_ReturnsFalse()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.DeleteSupplierAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task FindSupplierAsync_ReturnsEntity()
        {
            var id = 1;
            var supplierResponse = SupplierBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult(supplierResponse));

            var controllerResult = await _controller.FindSupplierAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, supplierResponse);
        }

        [Fact]
        public async Task FindSupplierAsync_ReturnsNull()
        {
            var id = 1;
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult<SupplierResponse>(null));

            var controllerResult = await _controller.FindSupplierAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task FindAllSuppliersAsync_ReturnsEntity()
        {
            var suppliersResponseList = new List<SupplierResponse>
            {
                SupplierBuilder.NewObject().ResponseBuild()
            };
            _service.Setup(s => s.FindAllEntitiesAsync()).Returns(Task.FromResult(suppliersResponseList));

            var controllerResult = await _controller.FindAllSuppliersAsync();

            _service.Verify(s => s.FindAllEntitiesAsync(), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, suppliersResponseList);
        }

        [Fact]
        public async Task FindAllSuppliersAsync_ReturnsNull()
        {
            _service.Setup(s => s.FindAllEntitiesAsync()).Returns(Task.FromResult<List<SupplierResponse>>(null));

            var controllerResult = await _controller.FindAllSuppliersAsync();

            _service.Verify(s => s.FindAllEntitiesAsync(), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task FindAllSuppliersPaginationAsync_ReturnsEntity()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            var suppliersResponseList = new List<SupplierResponse>
            {
                SupplierBuilder.NewObject().ResponseBuild()
            };
            var supplierResponsePageList = Utils.PageListBuilder<SupplierResponse>(suppliersResponseList);
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult(supplierResponsePageList));

            var controllerResult = await _controller.FindAllSuppliersPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, supplierResponsePageList);
        }

        [Fact]
        public async Task FindAllSuppliersPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult<PageList<SupplierResponse>>(null));

            var controllerResult = await _controller.FindAllSuppliersPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsTrue()
        {
            var supplierId = 1;
            var productId = 1;
            _service.Setup(s => s.AddProductAsync(supplierId, productId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.AddProductAsync(supplierId, productId);

            _service.Verify(s => s.AddProductAsync(supplierId, productId), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse()
        {
            var supplierId = 1;
            var productId = 1;
            _service.Setup(s => s.AddProductAsync(supplierId, productId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.AddProductAsync(supplierId, productId);

            _service.Verify(s => s.AddProductAsync(supplierId, productId), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsTrue()
        {
            var supplierId = 1;
            var productId = 1;
            _service.Setup(s => s.RemoveProductAsync(supplierId, productId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.RemoveProductAsync(supplierId, productId);

            _service.Verify(s => s.RemoveProductAsync(supplierId, productId), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsFalse()
        {
            var supplierId = 1;
            var productId = 1;
            _service.Setup(s => s.RemoveProductAsync(supplierId, productId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.RemoveProductAsync(supplierId, productId);

            _service.Verify(s => s.RemoveProductAsync(supplierId, productId), Times.Once());
            Assert.False(controllerResult);
        }
    }
}
