using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPessoaApplication : IApplicationBase<Pessoa, PessoaDTO>
    {
        UsuarioLogadoDTO Login(LoginDTO data);
        PessoaDTO GetByEmailSenha(string email, string senha);
    }
}
