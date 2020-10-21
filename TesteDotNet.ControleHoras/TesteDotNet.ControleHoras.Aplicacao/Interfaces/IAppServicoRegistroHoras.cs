using Aplicacao.Principal;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace TesteDotNet.ControleHoras.Aplicacao.Interfaces
{
    public interface IAppServicoRegistroHoras
    {
        Task<ICadastroSalvarResultado> InserirAsync(RegistroHoraDTO dto);
        Task<ICadastroSalvarResultado> UpdateAsync(RegistroHoraDTO dto);
        Task<ICadastroSalvarResultado> UpdatePatchAsync(int id, JsonPatchDocument<RegistroHoraDTO> dtoPatch);
        Task<ICadastroSalvarResultado> DeleteAsync(int id);
        Task<RegistroHoraDTO> GetByIdAsync(int id);
        Task<List<RegistroHoraDTO>> GetAllAsync();        
        Task<bool> ExistsAsync(int id);

        void Dispose();
    }
}
