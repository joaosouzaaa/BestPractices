namespace BestPractices.ApplicationService.Request.Client
{
    public class ClientUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocumentNumber { get; set; }
    }
}
