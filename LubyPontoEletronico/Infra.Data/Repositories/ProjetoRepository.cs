using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Contexts;
using Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class ProjetoRepository : RepositoryBase<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(Context con) : base(con)
        {
        }
    }
}
