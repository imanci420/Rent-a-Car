using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly IJwtService jwtService;
        public LoginController(ILoginService loginService, IJwtService jwtService)
        {
            this.loginService = loginService;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> LogIn([FromBody] LoginDto model)
        {
            var user = await loginService.LogIn(model);

            if (user != null)
            {
                var tokenString = await jwtService.GenerateJWT(user);
                return Ok(new { token = tokenString });
            }
            else
                return BadRequest("Login Failed");
        }
    }
}
