using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;
using LubyClocker.Domain.BoundedContexts.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LubyClocker.Application.BoundedContexts.Users.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> GenerateJwtToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));
            identityClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdAt = DateTime.UtcNow;
            var valid = createdAt.AddSeconds(_configuration.GetValue<int>("JWT_SECONDS"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = valid,
                Issuer = _configuration["JWT_ISSUER"],
                Audience = _configuration["JWT_AUDIENCE"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT_SECRET"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenResult = new AuthenticationResult
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                CreatedAt = createdAt,
                ExpiresAt = valid
            };

            return tokenResult;
        }
    }
}