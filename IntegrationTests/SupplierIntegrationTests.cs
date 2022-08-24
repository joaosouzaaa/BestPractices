using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
using Builders;
using IntegrationTests.Fixture;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class SupplierIntegrationTests : HttpClientFixture
    {
        [Fact]
        public async Task AddSupplierAsync_ReturnsSuccess()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            
            var postStatusCode = await AddSupplierAsync(supplierSaveRequest);

            Assert.Equal(postStatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddSupplierAsync_ReturnsBadRequest()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().WithCompanyName("aa").SaveRequestBuild();
            
            var postStatusCode = await AddSupplierAsync(supplierSaveRequest);

            Assert.Equal(postStatusCode, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateSupplierAsync_ReturnsSuccess()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            var postResult = await AddSupplierAsync(supplierSaveRequest);
            var supplierUpdateRequest = SupplierBuilder.NewObject().WithId(1).UpdateRequesBuild();

            var putResult = await CreatePutAsync("api/Supplier/update_supplier", supplierUpdateRequest);
            
            Assert.Equal(putResult, HttpStatusCode.OK);
            Assert.Equal(postResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsBadRequest()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            var postResult = await AddSupplierAsync(supplierSaveRequest);
            var supplierUpdateRequest = SupplierBuilder.NewObject().WithId(1).WithCompanyName("aa").UpdateRequesBuild();

            var putResult = await CreatePutAsync("api/Supplier/update_supplier", supplierUpdateRequest);

            Assert.Equal(putResult, HttpStatusCode.BadRequest);
            Assert.Equal(postResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsSuccess()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            var postResult = await AddSupplierAsync(supplierSaveRequest);

            var deleteResult = await CreateDeleteAsync("api/Supplier/delete_supplier?id=1");

            Assert.Equal(deleteResult, HttpStatusCode.OK);
            Assert.Equal(postResult, HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsBadRequest()
        {
            await AuthenticateAsync();

            var deleteResult = await CreateDeleteAsync("api/Supplier/delete_supplier?id=100");

            Assert.Equal(deleteResult, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task FindSupplierAsync_ReturnsEntity()
        {
            await AuthenticateAsync();
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            var postResult = await AddSupplierAsync(supplierSaveRequest);

            var supplierResponse = await CreateGetAsync<SupplierResponse>("api/Supplier/find_supplier?id=1");

            Assert.Equal(postResult, HttpStatusCode.OK);
            Assert.NotNull(supplierResponse);
        }
        
        [Fact]
        public async Task FindAllSupplierAsync_ReturnsEntities()
        {
            await AuthenticateAsync();
            var supplierSaveRequestList = new List<SupplierSaveRequest>()
            {
                SupplierBuilder.NewObject().SaveRequestBuild(),
                SupplierBuilder.NewObject().SaveRequestBuild()
            };
            foreach(var supplierSaveRequest in supplierSaveRequestList)
            {
                var postResult = await CreatePostAsync("api/Supplier/add_supplier", supplierSaveRequest);
                Assert.Equal(postResult, HttpStatusCode.OK);
            }

            var getAllResult = await CreateGetAllAsync<SupplierResponse>("api/Supplier/findall_suppliers");

            Assert.Equal(getAllResult.Count, 2);
        }

        [Fact]
        public async Task FindAllSuppliersPaginationAsync_ReturnsEntities()
        {
            await AuthenticateAsync();
            var supplierSaveRequestList = new List<SupplierSaveRequest>()
            {
                SupplierBuilder.NewObject().SaveRequestBuild(),
                SupplierBuilder.NewObject().SaveRequestBuild()
            };
            foreach (var supplierSaveRequest in supplierSaveRequestList)
            {
                var postResult = await CreatePostAsync("api/Supplier/add_supplier", supplierSaveRequest);
                Assert.Equal(postResult, HttpStatusCode.OK);
            }

            var getAllPaginationResult = await CreateGetAllPageListAsync<SupplierResponse>("api/Supplier/findall_suppliers_pagination?PageSize=10&PageNumber=1");

            Assert.Equal(getAllPaginationResult.TotalCount, supplierSaveRequestList.Count);
        }

        private async Task<HttpStatusCode> AddSupplierAsync(SupplierSaveRequest supplierSaveRequest) =>
            await CreatePostAsync("api/Supplier/add_supplier", supplierSaveRequest);
    }
}
