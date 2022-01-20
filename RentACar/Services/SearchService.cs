using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class SearchService : ISearchService
    {
        private readonly RentACarDBContext context;
        public SearchService(RentACarDBContext context)
        {
            this.context = context;
        }
        public Task<List<Car>> SearchCar(SearchDto dto)
        {
            var cars = context.Cars.AsQueryable();

            if(!string.IsNullOrEmpty(dto.Location))
            {
                cars = cars.Where(c => c.Location.ToLower().Contains(dto.Location.ToLower()));
            }

            if(!string.IsNullOrEmpty(dto.Model))
            {
                cars = cars.Where(c => c.Model.ToLower().Contains(dto.Model.ToLower()));
            }

            if (!string.IsNullOrEmpty(dto.MinPrice.ToString()) && dto.MinPrice != 0)
            {
                cars = cars.Where(c => c.PricePerHour >= dto.MinPrice);
            }

            if (!string.IsNullOrEmpty(dto.MaxPrice.ToString()) && dto.MaxPrice != 0)
            {
                cars = cars.Where(c => c.PricePerHour <= dto.MaxPrice);
            }

            if (!string.IsNullOrEmpty(dto.Capacity.ToString()) && dto.Capacity != 0)
            {
                cars = cars.Where(c => c.Capacity == dto.Capacity);
            }

            if (!string.IsNullOrEmpty(dto.Color))
            {
                cars = cars.Where(c => c.Color.ToLower().Contains(dto.Color.ToLower()));
            }

            return cars.ToListAsync();
        }
    }
}
