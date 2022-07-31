using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.ShoppingCart;

namespace UnitTests.ControllerTests
{
    public class ShoppingCartControllerTests
    {
        Mock<IShoppingCartService> _service;
        ShoppingCartController _controller;

        public ShoppingCartControllerTests()
        {
            _service = new Mock<IShoppingCartService>();
            _controller = new ShoppingCartController(_service.Object);
        }

        [Fact]
        public async Task AddShoppingCartAsync_ReturnsTrue()
        {
            var shoppingCartSaveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(shoppingCartSaveRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.AddShoppingCartAsync(shoppingCartSaveRequest);

            _service.Verify(s => s.SaveAsync(shoppingCartSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddShoppingCartAsync_ReturnsFalse()
        {
            var shoppingCartSaveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.SaveAsync(shoppingCartSaveRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.AddShoppingCartAsync(shoppingCartSaveRequest);

            _service.Verify(s => s.SaveAsync(shoppingCartSaveRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task UpdateShoppingCartAsync_ReturnsTrue()
        {
            var shoppingCartUpdateRequest = ShoppingCartBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(shoppingCartUpdateRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.UpdateShoppingCartAsync(shoppingCartUpdateRequest);

            _service.Verify(s => s.UpdateAsync(shoppingCartUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateShoppingCartAsync_ReturnsFalse()
        {
            var shoppingCartUpdateRequest = ShoppingCartBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(shoppingCartUpdateRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.UpdateShoppingCartAsync(shoppingCartUpdateRequest);

            _service.Verify(s => s.UpdateAsync(shoppingCartUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task DeleteShoppingCartAsync_ReturnsTrue()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.DeleteShoppingCartAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteShoppingCartAsync_ReturnsFalse()
        {
            var id = 1;
            _service.Setup(s => s.DeleteAsync(id)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.DeleteShoppingCartAsync(id);

            _service.Verify(s => s.DeleteAsync(id), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task FindShoppingCartAsync_ReturnsEntity()
        {
            var id = 1;
            var shoppingCartResponse = ShoppingCartBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult(shoppingCartResponse));

            var controllerResult = await _controller.FindShoppingCartAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, shoppingCartResponse);
        }

        [Fact]
        public async Task FindShoppingCartAsync_ReturnsNull()
        {
            var id = 1;
            _service.Setup(s => s.FindByIdAsync(id)).Returns(Task.FromResult<ShoppingCartResponse>(null));

            var controllerResult = await _controller.FindShoppingCartAsync(id);

            _service.Verify(s => s.FindByIdAsync(id), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsTrue()
        {
            var shoppingCartId = 1;
            var productId = 1;
            _service.Setup(s => s.AddProductAsync(shoppingCartId, productId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.AddProductAsync(shoppingCartId, productId);

            _service.Verify(s => s.AddProductAsync(shoppingCartId, productId), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task AddProductAsync_ReturnsFalse()
        {
            var shoppingCartId = 1;
            var productId = 1;
            _service.Setup(s => s.AddProductAsync(shoppingCartId, productId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.AddProductAsync(shoppingCartId, productId);

            _service.Verify(s => s.AddProductAsync(shoppingCartId, productId), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsTrue()
        {
            var shoppingCartId = 1;
            var productId = 1;
            _service.Setup(s => s.RemoveProductAsync(shoppingCartId, productId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.RemoveProductAsync(shoppingCartId, productId);

            _service.Verify(s => s.RemoveProductAsync(shoppingCartId, productId), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task RemoveProductAsync_ReturnsFalse()
        {
            var shoppingCartId = 1;
            var productId = 1;
            _service.Setup(s => s.RemoveProductAsync(shoppingCartId, productId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.RemoveProductAsync(shoppingCartId, productId);

            _service.Verify(s => s.RemoveProductAsync(shoppingCartId, productId), Times.Once());
            Assert.False(controllerResult);
        }
    }
}
