using Hours.Domain.DTO;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLoginAsync(LoginDTO data);
    }
}
