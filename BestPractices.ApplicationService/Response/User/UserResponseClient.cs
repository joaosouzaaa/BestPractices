using BestPractices.ApplicationService.Response.Client;

namespace BestPractices.ApplicationService.Response.User
{
    public class UserResponseClient
    {
        public string Email { get; set; }
        public ClientResponse ClientResponse { get; set; }
    }
}
