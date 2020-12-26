using System.Threading.Tasks;
using test.domain.Dtos;

namespace test.domain.Interfaces.Services.DeveloperService
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto developer);
    }
}
