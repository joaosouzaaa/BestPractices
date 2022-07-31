using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.Braintree;
using Braintree;

namespace UnitTests.ControllerTests
{
    public class BraintreeControllerTests
    {
        Mock<IBraintreeService> _service;
        BraintreeController _controller;

        public BraintreeControllerTests()
        {
            _service = new Mock<IBraintreeService>();
            _controller = new BraintreeController(_service.Object);
        }

        [Fact]
        public async Task GetClientTokenAsync_ReturnsResponse()
        {
            var braintreeResponse = BraintreeBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.GenerateClientToken()).Returns(Task.FromResult(braintreeResponse));

            var controllerResult = await _controller.GetClientToken();
            
            _service.Verify(s => s.GenerateClientToken(), Times.Once);
            Assert.NotNull(controllerResult);
            Assert.Equal(braintreeResponse, controllerResult);
        }

        [Fact]
        public async Task GetClientTokenAsync_ReturnsNull()
        {
            _service.Setup(s => s.GenerateClientToken()).Returns(Task.FromResult<BraintreeResponse>(null));

            var controllerResult = await _controller.GetClientToken();

            _service.Verify(s => s.GenerateClientToken(), Times.Once);
            Assert.Null(controllerResult);
        }
    }
}
