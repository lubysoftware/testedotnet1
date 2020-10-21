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
    public class RepositorioProjeto : RepositorioBase<Projeto>, IRepositorioProjeto
    {
        private readonly DbContexto _dbContexto;

        public RepositorioProjeto(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override bool Exists(int id)
        {
            return _dbContexto.Projetos.Any(x => x.Id == id);
        }
        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbContexto.Projetos.AnyAsync(x => x.Id == id);
        }
    }
}
