using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration config;
        public JwtService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<string> GenerateJWT(User user)
        {
            var securityKey = await Task.Run(() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])));
            var credentials = await Task.Run(() => new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("role", user.Role.Name)
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(24.0),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
