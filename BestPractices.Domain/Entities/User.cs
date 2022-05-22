
using Microsoft.AspNetCore.Identity;

namespace BestPractices.Domain.Entities
{
    public class User : IdentityUser
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
