using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationbd.Models
{
    public class Tbl_Donor
    {
        [Required]
        public int Id { get; set; }
        public int SubKey => Id;
        public int Key => Id;

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
