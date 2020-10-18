using Aplicacao.Principal;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoDesenvolvedor
    {
        ICadastroSalvarResultado Inserir(DesenvolvedorDTO dto);
        ICadastroSalvarResultado Update(DesenvolvedorDTO dto);
        ICadastroSalvarResultado UpdatePatch(int id, JsonPatchDocument<DesenvolvedorDTO> dtoPatch);
        ICadastroSalvarResultado Delete(int id);

        DesenvolvedorDTO GetById(int id);
        Task<DesenvolvedorDTO> GetByIdAsync(int id);

        IEnumerable<DesenvolvedorDTO> GetAll();
        Task<List<DesenvolvedorDTO>> GetAllAsync();

        bool Exists(int id);        
        void Dispose();
    }
}
