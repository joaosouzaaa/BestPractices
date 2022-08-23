using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Domain.Entities;
using Bogus;

namespace Builders
{
    public class SupplierBuilder
    {
        private string _cnpj = "18369822000100";
        private string _companyName = "name of the comapbny";
        private int _id = new Faker().Random.Int(1, 1000);

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
                Id = _id,
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
                Id = _id
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
                Id = _id,
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

        public SupplierBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
    }
}
