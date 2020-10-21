using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Models;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces
{
    public interface IDesenvolvedorServico
    {
        public Task InserirAsync(DesenvolvedorModel desenvolvedorModel);
        public Task EditarAsync(DesenvolvedorModel desenvolvedorModel);
        public Task<IList<DesenvolvedorModel>> CarregarDesenvolvedoresAsync();
        public Task<DesenvolvedorModel> GetById(int id);
    }
}
