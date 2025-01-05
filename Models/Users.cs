using Microsoft.AspNetCore.Identity;

namespace project_asp.net.Models
{
    public class Users:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
