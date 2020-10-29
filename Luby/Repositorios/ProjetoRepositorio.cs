using Luby.Interfaces;
using Luby.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Repositorios
{
    public class ProjetoRepositorio : Repositorio<Projeto>, IRepositorio<Projeto>
    {
        public ProjetoRepositorio(DbContext context)
           : base(context)
        {

        }
    }
}