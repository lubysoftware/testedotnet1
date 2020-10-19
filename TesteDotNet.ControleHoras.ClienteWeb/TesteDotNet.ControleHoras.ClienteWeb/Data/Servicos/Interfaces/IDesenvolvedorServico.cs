using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Models;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces
{
    public interface IDesenvolvedorServico
    {
        public Task<IList<DesenvolvedorModel>> CarregarDesenvolvedoresAsync();
    }
}
