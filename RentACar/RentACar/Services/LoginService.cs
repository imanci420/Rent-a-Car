using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class LoginService : ILoginService
    {
        private readonly RentACarDBContext context;
        public LoginService(RentACarDBContext context)
        {
            this.context = context;
        }

        public async Task<User> LogIn(LoginDto model)
        {
            var user = await context.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Mail == model.Mail);
            var hashPassword = Task.Run(() => HashService.GenerateHashString(model.Password, user.Salt));

            return user.Password == await hashPassword ? user : null;
        }
    }
}
