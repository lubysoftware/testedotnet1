using Hours.Domain.DTO;
using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Login;
using Hours.Domain.Interfaces.Services.User;
using Hours.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Hours.Domain.Services.User
{
    public class LoginService : ILoginService
    {
        private SignInConfigurations _signInConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration;

        private ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository,
                            SignInConfigurations signInConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _signInConfigurations = signInConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLoginAsync(LoginDTO data)
        {
            var baseUser = new UsersEntity();

            if (data != null && !string.IsNullOrWhiteSpace(data.Email))
            {
                baseUser = await _loginRepository.FindByLoginAsync(data.Email);

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Failed to authenticate"
                    };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                             new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                             new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, data.Email)
                        });

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, data);
                }
            }
            else
                return new
                {
                    authenticated = false,
                    message = "Failed to authenticate"
                };
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Isseur,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signInConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                UserName = user.Email,
                message = "User successfully logged in"
            };
        }
    }
}