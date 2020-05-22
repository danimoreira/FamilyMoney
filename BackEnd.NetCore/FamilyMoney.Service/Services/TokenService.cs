using FamilyMoney.Domain.Entities;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FamilyMoney.Service.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Member member)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keySecret = Encoding.ASCII.GetBytes(Settings.KeySecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, member.Username.ToString()),
                    new Claim(ClaimTypes.Role, member.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keySecret), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}