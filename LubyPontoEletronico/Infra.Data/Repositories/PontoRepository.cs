using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Contexts;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class PontoRepository : RepositoryBase<Ponto>, IPontoRepository
    {
        public PontoRepository(Context con) : base(con)
        {
        }

        public List<Pessoa> GetMediaPonto(List<DateTime> dataSemana)
        {
            return _con.Pessoa.Include(x => x.Pontos).Where(x => x.Pontos.Any(z => z.DataInicio >= dataSemana[0] && z.DataInicio <= dataSemana[1])).ToList();
        }
    }
}
