using Aplicacao.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Principal.Interfaces
{
    public interface IAppServicoAutenticacao
    {
        Task<UsuarioDTO> GetUsuario(UsuarioDTO usuario);
    }
}
