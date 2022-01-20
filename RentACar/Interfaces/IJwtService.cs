using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateJWT(User user);
    }
}
