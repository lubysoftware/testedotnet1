using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioRegistroHora : RepositorioBase<RegistroHora>, IRepositorioRegistroHora
    {
        private readonly DbContexto _dbContexto;

        public RepositorioRegistroHora(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override bool Exists(int id)
        {
            return _dbContexto.RegistroHoras.Any(x => x.Id == id);
        }
        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbContexto.RegistroHoras.AnyAsync(x => x.Id == id);
        }
    }
}
