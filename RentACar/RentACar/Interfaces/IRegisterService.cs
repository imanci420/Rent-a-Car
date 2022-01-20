using RentACar.Models;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface IRegisterService
    {
        Task<Customer> RegisterCustomer(Customer customer);

        Task<bool> IsEmailUnique(string mail);

        Task<bool> IsPassportNumberUnique(string passportNumber);

        Task<bool> IsDebitCardUnique(string debitCard);
    }
}
