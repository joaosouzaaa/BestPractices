using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Domain.Entities;
using ExpectedObjects;
using UnitTests.AutoMapperTests.BaseAutoMapper;

namespace UnitTests.AutoMapperTests
{
    public class ProductAutoMapperTests : PageListBuild<Product, ProductResponse>
    {
        public Product Product = ProductBuilder.NewObject().DomainBuild();

        [Fact]
        public void Product_To_ProductSaveRequest()
        {
            var productSaveRequest = Product.MapTo<Product, ProductSaveRequest>();

            Assert.Equal(productSaveRequest.ProductName, Product.ProductName);
            Assert.Equal(productSaveRequest.Price, Product.Price);
            Assert.Equal(productSaveRequest.Brand, Product.Brand);
            Assert.Equal(productSaveRequest.Description, Product.Description);
            Assert.Equal(productSaveRequest.SupplierId, Product.SupplierId);
            Assert.Equal(productSaveRequest.ShoppingCartId, Product.ShoppingCartId);
            Assert.Equal(productSaveRequest.TransportationPrice, Product.TransportationPrice);
            Assert.Equal((ushort)productSaveRequest.Category, (ushort)Product.Category);
        }

        [Fact]
        public void Product_To_ProductUpdateRequest()
        {
            var productUpdateRequest = Product.MapTo<Product, ProductUpdateRequest>();

            Assert.Equal(productUpdateRequest.Id, Product.Id);
            Assert.Equal(productUpdateRequest.ProductName, Product.ProductName);
            Assert.Equal(productUpdateRequest.Price, Product.Price);
            Assert.Equal(productUpdateRequest.Brand, Product.Brand);
            Assert.Equal(productUpdateRequest.Description, Product.Description);
            Assert.Equal(productUpdateRequest.TransportationPrice, Product.TransportationPrice);
            Assert.Equal((ushort)productUpdateRequest.Category, (ushort)Product.Category);
        }

        [Fact]
        public void Product_To_ProductResponse()
        {
            var productResponse = Product.MapTo<Product, ProductResponse>();

            Assert.Equal(productResponse.Id, Product.Id);
            Assert.Equal(productResponse.ProductName, Product.ProductName);
            Assert.Equal(productResponse.Price, Product.Price);
            Assert.Equal(productResponse.Brand, Product.Brand);
            Assert.Equal(productResponse.Description, Product.Description);
            Assert.Equal(productResponse.TransportationPrice, Product.TransportationPrice);
            Assert.Equal((ushort)productResponse.Category, (ushort)Product.Category);
        }
    }
}
