using System.ComponentModel.DataAnnotations;

namespace BloodDonationbd.Models
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "E-Mail is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
