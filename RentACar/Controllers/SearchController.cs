using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet("car")]
        public async Task<List<Car>> SearchCars([FromQuery] SearchDto dto) => await searchService.SearchCar(dto);
    }
}
