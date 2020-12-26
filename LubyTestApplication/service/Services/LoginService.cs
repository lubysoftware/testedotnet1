using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using test.domain.Dtos;
using test.domain.Entities;
using test.domain.Interfaces.Repositories;
using test.domain.Interfaces.Services.DeveloperService;
using test.domain.Security;

namespace test.service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDeveloperRepository _developerRepository;
        public SigningConfigurations _signingConfigurations;
        public TokenConfigurations _tokenConfigurations;

        private IConfiguration _configuration { get; }

        public LoginService(IDeveloperRepository developerRepository,
                              SigningConfigurations signingConfigurations,
                              TokenConfigurations tokenConfigurations,
                              IConfiguration configuration)
        {
            _developerRepository = developerRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }


        public async Task<object> FindByLogin(LoginDto developer)
        {
            var baseUser = new Developer();
            if (developer != null && !string.IsNullOrWhiteSpace(developer.Email))
            {
                baseUser = await _developerRepository.FindByLogin(developer.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(developer.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, developer.Email),
                        }
                    );

                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, baseUser);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, Developer developer)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = developer.Email,
                name = developer.Name,
                message = "Usuário Logado com sucesso"
            };
        }

    }
}