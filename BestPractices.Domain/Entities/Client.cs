using BestPractices.Domain.Entities.EntityBase;

namespace BestPractices.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocumentNumber { get; set; }
    }
}
