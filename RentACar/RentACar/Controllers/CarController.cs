using Microsoft.AspNetCore.Mvc;

using RentACar.Interfaces;
using RentACar.Models;
using RentACar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("{id}")]
        public async Task<Car> GetCarById([FromRoute] int id) => await carService.GetCarById(id);

        [HttpGet]
        public async Task<List<Car>> GetCars() => await carService.GetAllCars();

        [HttpDelete("delete/{id}")]
        public async Task DeleteCar([FromRoute] int id) => await carService.DeleteCar(id);

        [HttpPost("create")]
        public async Task CreateCar([FromBody] Car car) => await carService.CreateCar(car);

        [HttpPut("update")]
        public async Task UpdateCar([FromBody] Car car) => await carService.UpdateCar(car);

    }
}
