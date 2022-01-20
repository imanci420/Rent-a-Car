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
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;
        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [HttpPost]
        public async Task RegisterCustomer([FromBody] Customer customer) => await registerService.RegisterCustomer(customer);
    }
}
