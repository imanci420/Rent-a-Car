using System;

namespace RentACar.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
