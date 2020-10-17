using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoDesenvolvedor
    {
        DesenvolvedorDTO Add(DesenvolvedorDTO dto);
        
        DesenvolvedorDTO GetById(int id);
        Task<DesenvolvedorDTO> GetByIdAsync(int id);

        IEnumerable<DesenvolvedorDTO> GetAll();
        Task<List<DesenvolvedorDTO>> GetAllAsync();

        void Update(DesenvolvedorDTO dto);

        void Remove(DesenvolvedorDTO dto);

        void Dispose();
    }
}
