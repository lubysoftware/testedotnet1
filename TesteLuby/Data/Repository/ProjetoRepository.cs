using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(ApiDbContext db) : base(db) { }

        public async Task<Projeto> ObterProjetoPorNome(string nome)
        {
            return await Db.Projetos.AsNoTracking()
                .Where(c => c.Nome == nome)
                .FirstOrDefaultAsync();
        }
    }
}