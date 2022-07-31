using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Business.Settings.PaginationSettings;
using UnitTests.Builders.Helpers;

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
            _service.Setup(s => s.SaveAsync(productSaveRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.AddProductAsync(productSaveRequest);

            _service.Verify(s => s.SaveAsync(productSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse()
        {
            var productSaveRequest = ProductBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(productSaveRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.AddProductAsync(productSaveRequest);

            _service.Verify(s => s.SaveAsync(productSaveRequest), Times.Once());
            Assert.False(controllerResult); 
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsTrue()
        {
            var productUpdateRequest = ProductBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(productUpdateRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.UpdateProductAsync(productUpdateRequest);

            _service.Verify(s => s.UpdateAsync(productUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsFalse()
        {
            var productUpdateRequest = ProductBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(productUpdateRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.UpdateProductAsync(productUpdateRequest);

            _service.Verify(s => s.UpdateAsync(productUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task DeleteProductAsync_ReturnsTrue()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.DeleteProductAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteProductAsync_ReturnsFalse()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.DeleteProductAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task FindProductAsync_ReturnsEntity()
        {
            var id = 1;
            var productResponse = ProductBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult(productResponse));

            var controllerResult = await _controller.FindProductAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, productResponse);
        }

        [Fact]
        public async Task FindProductAsync_ReturnsNull()
        {
            var id = 1;
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult<ProductResponse>(null));

            var controllerResult = await _controller.FindProductAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task FindAllProductsAsync_ReturnsEntity()
        {
            var productsResponseList = new List<ProductResponse>();
            productsResponseList.Add(ProductBuilder.NewObject().ResponseBuild());
            _service.Setup(s => s.FindAllEntitiesAsync()).Returns(Task.FromResult(productsResponseList));

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
            var productResponsePageList = Utils.PageListBuilder<ProductResponse>(productsResponseList);
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult(productResponsePageList));

            var controllerResult = await _controller.FindAllProductsPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, productResponsePageList);
        }

        [Fact]
        public async Task FindAllProductsPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult<PageList<ProductResponse>>(null));

            var controllerResult = await _controller.FindAllProductsPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.Null(controllerResult);
        }
    }
}
