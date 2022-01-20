using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class CityService : ICityService
    {
        private readonly RentACarDBContext context;

        public CityService(RentACarDBContext context)
        {
            this.context = context;
        }

        public async Task<List<City>> GetAllCities() => await context.Cities.ToListAsync();

        public async Task<City> GetCityById(int id) => await context.Cities.SingleOrDefaultAsync(c => c.Id == id);

        public async Task CreateCity(City city)
        {
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCity(int id)
        {
            var city = await context.Cities.SingleOrDefaultAsync(c => c.Id == id);

            context.Cities.Remove(city);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCity(City city)
        {
            context.Cities.Update(city);
            await context.SaveChangesAsync();
        }
    }
}
