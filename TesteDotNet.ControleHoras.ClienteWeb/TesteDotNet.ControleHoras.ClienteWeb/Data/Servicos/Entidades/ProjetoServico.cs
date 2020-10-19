using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Models;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Entidades
{
    public class ProjetoServico : IProjetoServico
    {
        public async Task<IList<ProjetoModel>> CarregarProjetosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task EditarAsync(ProjetoModel projetoModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjetoModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InserirAsync(ProjetoModel projetoModel)
        {
            throw new NotImplementedException();
        }
    }
}
