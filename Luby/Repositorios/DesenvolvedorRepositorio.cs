using Luby.Interfaces;
using Luby.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Repositorios
{
    public class DesenvolvedorRepositorio : Repositorio<Desenvolvedor>, IRepositorio<Desenvolvedor>
    {
        public DesenvolvedorRepositorio(DbContext context)
           : base(context)
        {

        }

        public async Task<Desenvolvedor> LoginAsync(string email, string senha )
        {
            Desenvolvedor obj = await FindBy(p => p.Email == email && p.Senha == senha)
                .FirstOrDefaultAsync();

            return obj;
        }
    }
}
