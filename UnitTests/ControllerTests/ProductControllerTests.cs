using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Business.Settings.PaginationSettings;
using Builders;
using Builders.Helpers;

namespace UnitTests.ControllerTests
{
    public class ProductControllerTests
    {
        Mock<IProductService> _service;
        ProductController _controller;

        public ProductControllerTests()
        {
            _service = new Mock<IProductService>();
            _controller = new ProductController(_service.Object);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsTrue()
        {
            var productSaveRequest = ProductBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(productSaveRequest)).ReturnsAsync(true);

            var controllerResult = await _controller.AddProductAsync(productSaveRequest);

            _service.Verify(s => s.SaveAsync(productSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse()
        {
            var productSaveRequest = ProductBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(productSaveRequest)).ReturnsAsync(false);

            var controllerResult = await _controller.AddProductAsync(productSaveRequest);

            _service.Verify(s => s.SaveAsync(productSaveRequest), Times.Once());
            Assert.False(controllerResult); 
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsTrue()
        {
            var productUpdateRequest = ProductBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(productUpdateRequest)).ReturnsAsync(true);

            var controllerResult = await _controller.UpdateProductAsync(productUpdateRequest);

            _service.Verify(s => s.UpdateAsync(productUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsFalse()
        {
            var productUpdateRequest = ProductBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(productUpdateRequest)).ReturnsAsync(false);

            var controllerResult = await _controller.UpdateProductAsync(productUpdateRequest);

            _service.Verify(s => s.UpdateAsync(productUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task DeleteProductAsync_ReturnsTrue()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);

            var controllerResult = await _controller.DeleteProductAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteProductAsync_ReturnsFalse()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).ReturnsAsync(false);

            var controllerResult = await _controller.DeleteProductAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task FindProductAsync_ReturnsEntity()
        {
            var id = 1;
            var productResponse = ProductBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.FindByIdAsync(id)).ReturnsAsync(productResponse);

            var controllerResult = await _controller.FindProductAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, productResponse);
        }

        [Fact]
        public async Task FindProductAsync_ReturnsNull()
        {
            var id = 1;

            var controllerResult = await _controller.FindProductAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task FindAllProductsAsync_ReturnsEntity()
        {
            var productsResponseList = new List<ProductResponse>();
            productsResponseList.Add(ProductBuilder.NewObject().ResponseBuild());
            _service.Setup(s => s.FindAllEntitiesAsync()).ReturnsAsync(productsResponseList);

            var controllerResult = await _controller.FindAllProductsAsync();

            _service.Verify(s => s.FindAllEntitiesAsync(), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, productsResponseList);
        }

        [Fact]
        public async Task FindAllProductsPaginationAsync_ReturnsEntity()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            var productsResponseList = new List<ProductResponse>();
            productsResponseList.Add(ProductBuilder.NewObject().ResponseBuild());
            var productResponsePageList = Utils.PageListBuilder(productsResponseList);
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).ReturnsAsync(productResponsePageList);

            var controllerResult = await _controller.FindAllProductsPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, productResponsePageList);
        }

        [Fact]
        public async Task FindAllProductsPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();

            var controllerResult = await _controller.FindAllProductsPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.Null(controllerResult);
        }
    }
}
