namespace BloodDonationbd.Models
{
    public class BloodReciver
    {
        public int Id { get; set; }
        public string ReciverName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string? ReciverPhoto { get; set; }
        public DateTime CraetedOn { get; set; }
    }
}
