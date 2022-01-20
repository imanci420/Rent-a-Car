using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface IRentService
    {
        public Task RentACar(Rent rent);
    }
}
