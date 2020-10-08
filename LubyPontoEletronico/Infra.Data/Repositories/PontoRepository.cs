using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Contexts;
using Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class PontoRepository : RepositoryBase<Ponto>, IPontoRepository
    {
        public PontoRepository(Context con) : base(con)
        {
        }
    }
}
