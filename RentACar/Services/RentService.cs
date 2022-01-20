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

        public async Task ExtendRentPeriod(int rentId, DateTime newRentTime)
        {
            var rent = await context.Rents.SingleOrDefaultAsync(r => r.Id == rentId);
            var car = await context.Cars.SingleOrDefaultAsync(c => c.Id == rent.CarId);
            rent.RentTime = newRentTime;
            rent.RentCost = CalculateRentCost(rent.RentTime, car.PricePerHour);

            await context.SaveChangesAsync();
        }

        public async Task<Rent> GetCarRent(int carId)
        {
            var rents = await context.Rents.ToListAsync();
            var carRents = rents.FindAll(c => c.CarId == carId);

            var carWithMaxRentTime = carRents[0];
            for(int i = 0; i < carRents.Count; i++)
            {
                if(carWithMaxRentTime.RentTime < carRents[i].RentTime)
                {
                    carWithMaxRentTime = carRents[i];
                }
            }

            return carWithMaxRentTime;
        }

        public async Task RentACar(Rent rent)
        {
            var car = await context.Cars.SingleOrDefaultAsync(c => c.Id == rent.CarId);

            var price = car.PricePerHour;

            rent.RentCost = CalculateRentCost(rent.RentTime, price);
            await context.Rents.AddAsync(rent);

            car.Status = false;

            await context.SaveChangesAsync();
        }

        private decimal CalculateRentCost(DateTime rentTime, decimal price)
        {
            var cost = Convert.ToDecimal(rentTime.Subtract(DateTime.Now).TotalHours) * price;

            return cost;
        }
    }
}
