namespace RentACar.Models
{
    public class SearchDto
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
    }
}
