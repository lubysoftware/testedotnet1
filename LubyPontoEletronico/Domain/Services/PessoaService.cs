using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        protected readonly IPessoaRepository pessoaRepository;
        public PessoaService(IPessoaRepository repo) : base(repo)
        {
            pessoaRepository = repo;
        }

        public Pessoa GetByEmailSenha(string email, string senha)
        {
            return pessoaRepository.GetByEmailSenha(email, senha);
        }
    }
}
