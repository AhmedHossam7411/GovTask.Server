using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public User? User { get; set; }
    }
}
