using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Models;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces
{
    public interface IProjetoServico
    {
        public Task InserirAsync(ProjetoModel projetoModel);
        public Task EditarAsync(ProjetoModel projetoModel);
        public Task<IList<ProjetoModel>> CarregarProjetosAsync();
        public Task<ProjetoModel> GetById(int id);
    }
}
