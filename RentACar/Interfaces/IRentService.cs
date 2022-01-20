using RentACar.Models;
using System;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface IRentService
    {
        public Task RentACar(Rent rent);

        public Task<Rent> GetCarRent(int carId);

        public Task ExtendRentPeriod(int rentId, DateTime newRentTime);
    }
}
