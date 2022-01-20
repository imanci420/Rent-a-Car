using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface ISearchService
    {
        public Task<List<Car>> SearchCar(SearchDto dto);
    }
}
