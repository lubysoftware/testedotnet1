using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Login;
using Hours.Infra.Context;
using Hours.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hours.Infra.Implementation
{
    public class UserImplementation : BaseRepository<UsersEntity>, ILoginRepository
    {
        private DbSet<UsersEntity> _dataset;

        public UserImplementation(ContextDB context) : base(context)
        {
            _dataset = context.Set<UsersEntity>();
        }

        public async Task<UsersEntity> FindByLoginAsync(string email)
        {
            return await _dataset.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
