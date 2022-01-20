using System.Collections.Generic;

namespace RentACar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Transmission { get; set; }
        public decimal PricePerHour { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
        public string Location { get; set; }
        public string RegistrationNumber { get; set; }

        public int MarkId { get; set; }
        public Mark Mark { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Rent> Rents { get; set; } = new List<Rent>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
