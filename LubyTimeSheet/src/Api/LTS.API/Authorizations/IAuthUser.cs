using NetDevPack.Identity.Jwt.Model;
using System.Threading.Tasks;

namespace LTS.API.Authorizations
{
    public interface IAuthUser
    {
        Task<bool> CreateDefaultUserAdmin(string userName, string password);
        Task<UserResponse<string>> LoginAsync(LoginRequest loginUser);
    }
}
