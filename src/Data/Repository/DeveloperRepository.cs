using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;

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
        public DeveloperRepository(MyDbContext myDb) : base(myDb)
        {
        }
    }
}
