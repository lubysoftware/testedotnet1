using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioProjeto : RepositorioBase<Projeto>, IRepositorioProjeto
    {
        private readonly DbContexto _dbContexto;

        public RepositorioProjeto(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }
    }
}
