using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioDesenvolvedor : RepositorioBase<Desenvolvedor>, IRepositorioDesenvolvedor
    {
        private readonly DbContexto _dbContexto;

        public RepositorioDesenvolvedor(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override void Add(Desenvolvedor obj)
        {
            if (obj.ProjetoId == 0)
                obj.ProjetoId = null;

            base.Add(obj);
        }
    }
}
