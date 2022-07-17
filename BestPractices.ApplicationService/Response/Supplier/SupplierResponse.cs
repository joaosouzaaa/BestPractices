using BestPractices.ApplicationService.Response.Address;
using BestPractices.ApplicationService.Response.Product;

namespace BestPractices.ApplicationService.Response.Supplier
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }

        public AddressResponse CompanyAddressResponse { get; set; }
        public List<ProductResponse> ProductsResponse { get; set; }
    }
}
