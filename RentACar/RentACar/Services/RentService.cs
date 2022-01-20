using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class RentService : IRentService
    {
        private readonly RentACarDBContext context;
        public RentService(RentACarDBContext context)
        {
            this.context = context;
        }
        public async Task RentACar(Rent rent)
        {
            var car = await context.Cars.SingleOrDefaultAsync(c => c.Id == rent.CarId);

            rent.RentCost = Convert.ToDecimal(rent.RentTime.Subtract(DateTime.Now).TotalHours) * car.PricePerHour;
            car.Status = false;

            await context.Rents.AddAsync(rent);
            context.Cars.Update(car);

            await context.SaveChangesAsync();
        }
    }
}
