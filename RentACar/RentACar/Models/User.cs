using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [NotMapped]
        public string RepeatPassword { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
