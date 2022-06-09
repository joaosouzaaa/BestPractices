namespace BestPractices.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Excluded { get; set; } = false;
        public DateTime RegistrationDate { get; set; }
    }
}
