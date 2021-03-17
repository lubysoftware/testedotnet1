using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LTS.API.Authorizations
{
    public static class AuthUserExtensions
    {
        public static async Task<bool> UserExists<TUser>(this UserManager<TUser> userManager, string userName)
            where TUser : IdentityUser
        {
            return await userManager.FindByNameAsync(userName) != null;
        }
    }
}
