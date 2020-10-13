namespace Luby.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Model;
    using Luby.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    public class DesenvolvedorRepository : Repository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(LubyContext context) : base(context) {   }
        public async Task<IEnumerable<Projeto>> GetProjetos(int id)
            => await (from pd in _context.ProjetoDesenvolvedores.AsNoTracking()
                     join proj in _context.Projetos on pd.ProjetoId equals proj.Id
                     where pd.ProjetoId == id
                     select proj
                     ).ToListAsync();
    }
}