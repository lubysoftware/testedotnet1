using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioRegistroHora : RepositorioBase<RegistroHora>, IRepositorioRegistroHora
    {
        private readonly DbContexto _dbContexto;

        public RepositorioRegistroHora(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }
    }
}
