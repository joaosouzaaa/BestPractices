using Builders;
using IntegrationTests.Fixture;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class ProductIntegrationTests : HttpClientFixture
    {
        [Fact]
        public async Task AddProductAsync_ReturnsTrue()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            var postSupplierResult = await CreatePostAsync("api/Supplier/add_supplier", supplierSaveRequest);
            var productSaveRequest = ProductBuilder.NewObject().SaveRequestBuild();
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            var streamContent = new StreamContent(new MemoryStream(bytes));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            var multipartFormDataContent = new MultipartFormDataContent()
            {
                    { new StringContent(productSaveRequest.ProductName), "ProductName"},
                    { new StringContent(productSaveRequest.Price.ToString()), "Price"},
                    { new StringContent(productSaveRequest.Brand), "Brand"},
                    { new StringContent(productSaveRequest.Category.ToString()), "Category"},
                    { new StringContent(productSaveRequest.Description), "Description"},
                    { new StringContent(productSaveRequest.TransportationPrice.ToString()), "TransportationPrice"},
                    { streamContent, "image", "image.jpg" },
                    { new StringContent(productSaveRequest.SupplierId.ToString()), "SupplierId"},
            };

            var postResult = await _httpClient.PostAsync("api/Product/add_product", multipartFormDataContent);

            Assert.Equal(postSupplierResult, HttpStatusCode.OK);
            Assert.Equal(postResult.StatusCode, HttpStatusCode.OK);
        }
    }
}
