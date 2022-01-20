using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
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
    }
}
