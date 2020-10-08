using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPessoaService : IServiceBase<Pessoa>
    {
        Pessoa GetByEmailSenha(string email, string senha);
    }
}
