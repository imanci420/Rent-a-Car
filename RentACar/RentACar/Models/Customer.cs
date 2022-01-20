using System.Collections.Generic;

namespace RentACar.Models
{
    public class Customer : User
    {       
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string DebitCard { get; set; }

        public ICollection<Rent> Rents { get; set; } = new List<Rent>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
