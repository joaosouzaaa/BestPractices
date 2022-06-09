namespace BestPractices.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string CNPJ { get; set; }
        public string CompanyName { get; set; }
        
        public int CompanyAddressId { get; set; }
        public Address CompanyAddress { get; set; }
        public List<Product> Products { get; set; }
    }
}
