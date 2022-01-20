using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly RentACarDBContext context;
        public RegisterService(RentACarDBContext context)
        {
            this.context = context;
        }
        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            if (customer.Password != customer.RepeatPassword)
            {
                throw new Exception("Password mismatch");
            }

            if (!IsDebitCardUnique(customer.DebitCard).Result)
            {
                throw new Exception("Debit card is not unique");
            }

            if (!IsEmailUnique(customer.Mail).Result)
            {
                throw new Exception("Email is not unique");
            }

            if (!IsPassportNumberUnique(customer.PassportNumber).Result)
            {
                throw new Exception("Passport number is not unique");
            }

            string salt = "";
            var hashPassword = Task.Run(() => HashService.GenerateHashString(customer.Password, ref salt));

            customer.Password = await hashPassword;
            customer.Salt = salt;

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return customer;
        }
        public async Task<bool> IsDebitCardUnique(string debitCard)
        {
            var customers = await context.Customers.ToListAsync();
            foreach (var customer in customers)
            {
                if(customer.DebitCard == debitCard)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsEmailUnique(string mail)
        {
            var customers = await context.Customers.ToListAsync();
            foreach (var customer in customers)
            {
                if (customer.Mail == mail)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsPassportNumberUnique(string passportNumber)
        {
            var customers = await context.Customers.ToListAsync();
            foreach (var customer in customers)
            {
                if (customer.PassportNumber == passportNumber)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
