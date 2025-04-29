using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationbd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
