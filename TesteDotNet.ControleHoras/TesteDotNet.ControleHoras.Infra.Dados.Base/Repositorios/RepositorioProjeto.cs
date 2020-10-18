using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using System.Linq;

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
    }
}
