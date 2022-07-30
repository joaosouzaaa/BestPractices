using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Domain.Entities;
using ExpectedObjects;
using UnitTests.AutoMapperTests.BaseAutoMapper;

namespace UnitTests.AutoMapperTests
{
    public class SupplierAutoMapperTests : PageListBuild<Supplier, SupplierResponse>
    {
        public Supplier Supplier = SupplierBuilder.NewObject().DomainBuild();

        [Fact]
        public void Supplier_To_SupplierSaveRequest() =>
            Supplier.MapTo<Supplier, SupplierSaveRequest>().ToExpectedObject().ShouldMatch(Supplier);

        [Fact]
        public void Supplier_To_SupplierUpdateRequest() =>
            Supplier.MapTo<Supplier, SupplierUpdateRequest>().ToExpectedObject().ShouldMatch(Supplier);

        [Fact]
        public void Supplier_To_SupplierResponse() 
        {
            var supplierResponse = Supplier.MapTo<Supplier, SupplierResponse>();

            Assert.Equal(supplierResponse.Id, Supplier.Id);
            Assert.Equal(supplierResponse.CNPJ, Supplier.CNPJ);
            Assert.Equal(supplierResponse.CompanyName, Supplier.CompanyName);
            Assert.Equal(supplierResponse.ProductsResponse.Count, Supplier.Products.Count);
        }
    }
}
