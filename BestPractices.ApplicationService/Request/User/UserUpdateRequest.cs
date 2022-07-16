using BestPractices.ApplicationService.Request.Client;

namespace BestPractices.ApplicationService.Request.User
{
    public class UserUpdateRequest
    {
        public string Id { get; set; }
        public ClientUpdateRequest ClientUpdateRequest { get; set; }
    }
}
