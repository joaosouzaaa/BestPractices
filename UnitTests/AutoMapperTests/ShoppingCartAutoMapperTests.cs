using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;

namespace UnitTests.AutoMapperTests
{
    public class ShoppingCartAutoMapperTests
    {
        public ShoppingCart ShoppingCart = ShoppingCartBuilder.NewObject().DomainBuild();

        public ShoppingCartAutoMapperTests()
        {
            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public void ShoppingCart_To_ShoppingCartSaveRequest()
        {
            var shoppingCartSaveRequest = ShoppingCart.MapTo<ShoppingCart, ShoppingCartSaveRequest>();

            Assert.Equal(shoppingCartSaveRequest.UserId, ShoppingCart.UserId);
        }

        [Fact]
        public void ShoppingCart_To_ShoppingCartUpdateRequest()
        {
            var shoppingCartUpdateRequest = ShoppingCart.MapTo<ShoppingCart, ShoppingCartUpdateRequest>();

            Assert.Equal(shoppingCartUpdateRequest.TotalItens, ShoppingCart.TotalItens);
            Assert.Equal(shoppingCartUpdateRequest.TotalAmount, ShoppingCart.TotalAmount);
            Assert.Equal(shoppingCartUpdateRequest.Id, ShoppingCart.Id);
        }

        [Fact]
        public void ShoppingCart_To_ShoppingCartResponse()
        {
            var shoppingCartResponse = ShoppingCart.MapTo<ShoppingCart, ShoppingCartResponse>();

            Assert.Equal(shoppingCartResponse.Id, ShoppingCart.Id);
            Assert.Equal(shoppingCartResponse.TotalItens, ShoppingCart.TotalItens);
            Assert.Equal(shoppingCartResponse.TotalAmount, ShoppingCart.TotalAmount);
            Assert.Equal(shoppingCartResponse.Finished, ShoppingCart.Finished);
            Assert.Equal(shoppingCartResponse.ProductsResponse.Count, ShoppingCart.Products.Count);
        }
    }
}
