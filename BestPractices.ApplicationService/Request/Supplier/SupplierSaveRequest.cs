using BestPractices.ApplicationService.Request.Address;

namespace BestPractices.ApplicationService.Request.Supplier
{
    public class SupplierSaveRequest
    {
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }

        public AddressSaveRequest CompanyAddress { get; set; }
    }
}
