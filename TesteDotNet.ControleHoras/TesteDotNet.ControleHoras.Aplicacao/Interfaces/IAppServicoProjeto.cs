using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoProjeto
    {
        ProjetoDTO Add(ProjetoDTO obj);

        ProjetoDTO GetById(int id);

        IEnumerable<ProjetoDTO> GetAll();

        void Update(ProjetoDTO obj);

        void Remove(ProjetoDTO obj);

        void Dispose();
    }
}
