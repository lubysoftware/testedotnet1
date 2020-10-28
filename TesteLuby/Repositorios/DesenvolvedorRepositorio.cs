using Microsoft.EntityFrameworkCore;
using TesteLuby.Interfaces;
using TesteLuby.Models;

namespace TesteLuby.Repositorios
{
    public class DesenvolvedorRepositorio : Repositorio<Desenvolvedor>, IRepositorio<Desenvolvedor>
    {
        public DesenvolvedorRepositorio(DbContext context)
        : base(context)
        {

        }
    }
}
