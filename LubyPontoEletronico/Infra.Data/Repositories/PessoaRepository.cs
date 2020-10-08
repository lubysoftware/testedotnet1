using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Contexts;
using Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {       
        public PessoaRepository(Context con) : base(con)
        {
        }

        public Pessoa GetByEmailSenha(string email, string senha)
        {
            return _con.Pessoa.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }
    }
}
