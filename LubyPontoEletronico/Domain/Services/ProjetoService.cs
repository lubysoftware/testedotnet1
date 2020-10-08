using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ProjetoService : ServiceBase<Projeto>, IProjetoService
    {
        public ProjetoService(IProjetoRepository repo) : base(repo)
        {
        }
    }
}
