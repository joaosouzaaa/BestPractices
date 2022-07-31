using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class SupplierBuilder
    {
        private string _cnpj = "18369822000100";
        private string _companyName = "name of the comapbny";

        public static SupplierBuilder NewObject()
        {
            return new SupplierBuilder();
        }

        public Supplier DomainBuild()
        {
            var address = AddressBuilder.NewObject().DomainBuild();
            var productList = new List<Product>();
            productList.Add(ProductBuilder.NewObject().DomainBuild());
            return new Supplier
            {
                CompanyAddress = address,
                CNPJ = _cnpj,
                CompanyName = _companyName,
                Id = 1,
                Products = productList
            };
        }

        public SupplierSaveRequest SaveRequestBuild()
        {
            var addressSaveRequest = AddressBuilder.NewObject().SaveRequestBuild();
            return new SupplierSaveRequest
            {
                CompanyAddress = addressSaveRequest,
                CNPJ = _cnpj,
                CompanyName = _companyName
            };
        }

        public SupplierUpdateRequest UpdateRequesBuild()
        {
            var addressUpdateRequest = AddressBuilder.NewObject().UpdateRequestBuild();
            return new SupplierUpdateRequest
            {
                CompanyAddress = addressUpdateRequest,
                CNPJ = _cnpj,
                CompanyName = _companyName,
                Id = 1
            };
        }

        public SupplierResponse ResponseBuild()
        {
            var addressResponse = AddressBuilder.NewObject().ResponseBuild();
            return new SupplierResponse
            {
                CompanyAddressResponse = addressResponse,
                CNPJ = _cnpj,
                CompanyName = _companyName,
                Id = 1,
                ProductsResponse = new List<ProductResponse>()
            };
        }

        public SupplierBuilder WithCnpj(string cnpj)
        {
            _cnpj = cnpj;
            return this;
        }

        public SupplierBuilder WithCompanyName(string companyName)
        {
            _companyName = companyName;
            return this;
        }
    }
}
