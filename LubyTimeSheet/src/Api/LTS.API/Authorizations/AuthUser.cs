using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace LTS.API.Authorizations
{
    public class AuthUser : IAuthUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppJwtSettings _appJwtSettings;

        public AuthUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppJwtSettings> appJwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appJwtSettings = appJwtSettings.Value;
        }

        public async Task<UserResponse<string>> LoginAsync(LoginRequest loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, true, false);
            if (result.Succeeded)
            {
                return new JwtBuilder()
                    .WithUserManager(_userManager)
                    .WithJwtSettings(_appJwtSettings)
                    .WithEmail(loginUser.Username)
                    .WithJwtClaims()
                    .WithUserClaims()
                    .WithUserRoles()
                    .BuildUserResponse();
            }

            throw new InvalidCredentialException("Usuário ou senha incorretos");
        }

        public async Task<bool> CreateDefaultUserAdmin(string userName, string password)
        {
            var userExists = await _userManager.UserExists<IdentityUser>(userName);

            if (!userExists)
                return await SaveUserAsync(userName, password);

            return false;
        }

        private async Task<bool> SaveUserAsync(string userName, string password)
        {
            var defaultUser = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(defaultUser, password);

            if (result.Succeeded)
            {
                var resultRole = await _userManager.AddToRoleAsync(defaultUser, "administrator");

                return resultRole.Succeeded;
            }

            return result.Succeeded;
        }


    }
}
