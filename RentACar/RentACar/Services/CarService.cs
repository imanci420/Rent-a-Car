using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class CarService:ICarService
    {
        private readonly RentACarDBContext context;

        public CarService(RentACarDBContext context)
        {
            this.context = context;
        }
        public async Task<Car> GetCarById(int id) => await context.Cars.SingleOrDefaultAsync(c => c.Id == id);
        public async Task CreateCar(Car car)
        {
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
        }
        public async Task DeleteCar(int id)
        {
            var car = await context.Cars.SingleOrDefaultAsync(c => c.Id == id);
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCar(Car car)
        {
            context.Cars.Update(car);
            await context.SaveChangesAsync();
        }
        public async Task<List<Car>> GetAllCars() => await context.Cars.ToListAsync();
    }
}
