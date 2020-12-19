using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FabricaDeProjetos.Domain.Entities;
using FabricaDeProjetos;
using FabricaDeProjetos.Domain.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Core.Contracts;

namespace FabricaDeProjetos.Core
{
    public class TokenServiceCore : ITokenServiceCore
    {
        private IConfiguration _configuration;
        public TokenServiceCore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Developer user)
        {

            //AppSettings appSettings = new AppSettings();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}
