using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories.Login
{
    public interface ILoginRepository :IRepository<UsersEntity>
    {
        Task<UsersEntity> FindByLoginAsync(string email);
    }
}
