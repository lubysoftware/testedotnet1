using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PontoService : ServiceBase<Ponto>, IPontoService
    {
        public PontoService(IRepositoryBase<Ponto> repo) : base(repo)
        {
        }
    }
}
