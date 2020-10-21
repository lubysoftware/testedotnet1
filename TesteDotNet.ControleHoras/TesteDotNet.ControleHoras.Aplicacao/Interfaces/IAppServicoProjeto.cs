using Aplicacao.Principal;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoProjeto
    {        
        Task<ICadastroSalvarResultado> InserirAsync(ProjetoDTO dto);
        Task<ICadastroSalvarResultado> UpdateAsync(ProjetoDTO dto);
        Task<ICadastroSalvarResultado> UpdatePatchAsync(int id, JsonPatchDocument<ProjetoDTO> dtoPatch);
        Task<ICadastroSalvarResultado> DeleteAsync(int id);
        Task<ProjetoDTO> GetByIdAsync(int id);
        Task<List<ProjetoDTO>> GetAllAsync();
        Task<bool> ExistsAsync(int id);

        void Dispose();
    }
}
