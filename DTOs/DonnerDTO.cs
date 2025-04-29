using System.ComponentModel.DataAnnotations;

namespace BloodDonationbd.DTOs
{
    public record   DonnerDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-Mail is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required]
        public string BloodGroup { get; set; }
    }
}
