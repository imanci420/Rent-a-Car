using RentACar.Models;
using RentACar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface ICarService
    {
        Task CreateCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(int Id);
        Task<List<Car>> GetAllCars();
        Task<Car> GetCarById(int Id);

        Task ChangeCarStatus(int carId, bool newStatus);
    }
}
