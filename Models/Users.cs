using Microsoft.AspNetCore.Identity;

namespace BloodDonationbd.Models
{
    public class Users:IdentityUser
    {
        public string FullName { get; set; }
    }
}
