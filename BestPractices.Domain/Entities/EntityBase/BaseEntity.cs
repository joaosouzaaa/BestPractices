namespace BestPractices.Domain.Entities.EntityBase
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Excluded { get; set; } = false;
        public DateTime RegistrationDate { get; set; }
    }
}
