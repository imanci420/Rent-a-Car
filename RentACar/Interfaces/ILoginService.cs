using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface ILoginService
    {
        Task<User> LogIn(LoginDto model);
    }
}
