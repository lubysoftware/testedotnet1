using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using System.Linq;

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
    }
}
