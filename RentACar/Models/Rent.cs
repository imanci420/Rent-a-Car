using System;

namespace RentACar.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime RentTime { get; set; }
        public decimal RentCost { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
