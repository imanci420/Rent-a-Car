using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.DataAccess
{
    public class RentACarDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public RentACarDBContext(DbContextOptions<RentACarDBContext> options) : base(options) {}
    }
}
