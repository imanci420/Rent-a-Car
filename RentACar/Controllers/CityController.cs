using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<City> GetCityById([FromRoute] int id) => await cityService.GetCityById(id);

        [HttpGet]
        public async Task<List<City>> GetCities() => await cityService.GetAllCities();

        [HttpDelete("delete/{id}")]
        public async Task DeleteCity([FromRoute] int id) => await cityService.DeleteCity(id);

        [HttpPost("create")]
        public async Task CreateCity([FromBody] City city) => await cityService.CreateCity(city);

        [HttpPut("update")]
        public async Task UpdateCity([FromBody]City city) => await cityService.UpdateCity(city);

    }
}
