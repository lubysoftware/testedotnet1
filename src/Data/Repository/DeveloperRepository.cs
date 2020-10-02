using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    /// <summary>
    /// Classe de repositorio do desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(MyDbContext myDb) : base(myDb) { }

        public async Task<Developer> GetByIdToRemove(Guid id)
        {
            return await Db.Developers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
