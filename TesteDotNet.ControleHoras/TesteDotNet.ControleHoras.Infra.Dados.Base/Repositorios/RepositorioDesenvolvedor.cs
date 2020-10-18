using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioDesenvolvedor : RepositorioBase<Desenvolvedor>, IRepositorioDesenvolvedor
    {
        protected readonly DbContexto _dbContexto;

        public RepositorioDesenvolvedor(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override bool Exists(int id)
        {
            return _dbContexto.Desenvolvedores.Any(x => x.Id == id);
        }
    }
}
