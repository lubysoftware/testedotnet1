using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DesenvolvedorRepository : Repository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(ApiDbContext db) : base(db)
        {
        }

        public async Task<Desenvolvedor> ObterDesenvolvedorPorEmail(string email)
        {
            return await Db.Desenvolvedores.AsNoTracking()
                .Where(d => d.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}