using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoRegistroHoras
    {
        void Add(RegistroHoraDTO obj);

        RegistroHoraDTO GetById(int id);

        IEnumerable<RegistroHoraDTO> GetAll();

        void Update(RegistroHoraDTO obj);

        void Remove(RegistroHoraDTO obj);

        void Dispose();
    }
}
