using LubySoftware.Authentication.Models;
using LubySoftware.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LubySoftware.Authentication.Services
{
    public class AuthenticationService
    {
        public JwtTokenModel Authentication(UserModel user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserId) || string.IsNullOrEmpty(user.Password))
                throw new Exception("O usuário e a senha devem ser informados");

            //TODO: Deverá ser implementar a lógica de autenticação
            if (user.UserId != "teste" || user.Password != "123123")
                throw new Exception("O usuário ou a senha está incorreto");

            //TODO: Deserá ser criado um cadastro parâmetro de tempo de vida
            return CreateToken(user, 5, "LAf.,)j0yx0e|9pQe)]KI&uZM[.$bcdmc8aPs9*IXimXI}nm#hy+OKLbC|Gebk(4KI+3)2@HCOeKI)y+QN7gY-8b)%6KQo&by1^");
        }


        private JwtTokenModel CreateToken(UserModel user, int expirationTime, string apiSecret)
        {
            DateTime createDate = DateTime.UtcNow;
            DateTime expirationDate = createDate.AddMinutes(expirationTime);

            byte[] key = Encoding.ASCII.GetBytes(apiSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId),
                }),
                NotBefore = createDate,
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            JwtTokenModel jwtTokenModel = new JwtTokenModel
            {
                Authenticated = true,
                Created = createDate,
                Expiration = expirationDate,
                AccessToken = token
            };

            return jwtTokenModel;
        }
    }
}
