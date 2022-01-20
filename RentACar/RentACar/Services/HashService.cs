using System;
using System.Security.Cryptography;
using System.Text;

namespace RentACar.Services
{
    public class HashService
    {
        public static string GenerateHashString(string password, ref string Salt)
        {
            Salt = GenerateSalt();

            var saltedPassword = password + Salt;
            var bytePassword = Encoding.UTF8.GetBytes(saltedPassword);

            HashAlgorithm algorithm = new SHA512Managed();
            byte[] hashPassword = algorithm.ComputeHash(bytePassword);
            var base64Hash = Convert.ToBase64String(hashPassword);

            return base64Hash;
        }
        public static string GenerateHashString(string password, string Salt)
        {
            var saltedPass = password + Salt;
            var saltedHash = Encoding.UTF8.GetBytes(saltedPass);

            HashAlgorithm algorithm = new SHA512Managed();
            byte[] hashPassword = algorithm.ComputeHash(saltedHash);
            var base64Hash = Convert.ToBase64String(hashPassword);

            return base64Hash;
        }

        private static string GenerateSalt()
        {
            Random random = new();
            int MinSaltSize = 4;
            int MaxSaltSize = 8;

            int SaltSize = random.Next(MinSaltSize, MaxSaltSize);

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            return Convert.ToBase64String(salt);
        }
    }
}
