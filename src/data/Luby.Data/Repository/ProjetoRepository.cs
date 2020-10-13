namespace Luby.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Model;
    using Luby.Data.Context;
    using Microsoft.EntityFrameworkCore;
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(LubyContext context) : base(context) { }
        public async Task<IEnumerable<Desenvolvedor>> GetDesenvolvedores(int id)
            => await (from pd in _context.ProjetoDesenvolvedores.AsNoTracking()
                     join dev in _context.Desenvolvedores on pd.DesenvolvedorId equals dev.Id
                     where pd.ProjetoId == id
                     select dev)
                     .ToListAsync();

        public async Task LancarHoras(ProjetoDesenvolvedores entity)
        {
            _context.ProjetoDesenvolvedores.Add(entity);

            await SaveChange();
        }
    }
}