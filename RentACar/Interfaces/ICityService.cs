using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface ICityService
    {
        Task CreateCity(City city);

        Task UpdateCity(City city);

        Task DeleteCity(int id);

        Task<List<City>> GetAllCities();

        Task<City> GetCityById(int id);
    }
}
