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
        Task<ICadastroSalvarResultado> InserirAsync(DesenvolvedorDTO dto);

        ICadastroSalvarResultado Update(DesenvolvedorDTO dto);
        Task<ICadastroSalvarResultado> UpdateAsync(DesenvolvedorDTO dto);

        ICadastroSalvarResultado UpdatePatch(int id, JsonPatchDocument<DesenvolvedorDTO> dtoPatch);
        Task<ICadastroSalvarResultado> UpdatePatchAsync(int id, JsonPatchDocument<DesenvolvedorDTO> dtoPatch);

        ICadastroSalvarResultado Delete(int id);
        Task<ICadastroSalvarResultado> DeleteAsync(int id);

        DesenvolvedorDTO GetById(int id);
        Task<DesenvolvedorDTO> GetByIdAsync(int id);

        IEnumerable<DesenvolvedorDTO> GetAll();
        Task<List<DesenvolvedorDTO>> GetAllAsync();

        bool Exists(int id);
        Task<bool> ExistsAsync(int id);

        void Dispose();
    }
}
