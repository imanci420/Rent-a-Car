using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentService rentService;
        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpPost]
        public async Task RentACar([FromBody] Rent rent) => await rentService.RentACar(rent);

        [HttpGet("car/{carId}")]
        public async Task<Rent> GetCarRent([FromRoute] int carId) => await rentService.GetCarRent(carId);

        [HttpPut("extendRent/{rentId}")]
        public async Task ExtendRentPeriod([FromBody] DateTime newRentTime, [FromRoute] int rentId) => await rentService.ExtendRentPeriod(rentId, newRentTime);
    }
}
