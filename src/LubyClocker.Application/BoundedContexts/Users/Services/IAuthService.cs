using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;

namespace LubyClocker.Application.BoundedContexts.Users.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResult> GenerateJwtToken(string username);
    }
}