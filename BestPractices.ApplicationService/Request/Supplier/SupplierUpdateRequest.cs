using BestPractices.ApplicationService.Request.Address;

namespace BestPractices.ApplicationService.Request.Supplier
{
    public class SupplierUpdateRequest
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }

        public AddressUpdateRequest CompanyAddress { get; set; }
    }
}
