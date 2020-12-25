using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    public class LubyTestDB : DbContext
    {
        public LubyTestDB(DbContextOptions<LubyTestDB> db): base(db)
        { }
        public DbSet<BancoHorasTable> BancoHoras {get;set;}
        public DbSet<DesenvolvedorTable> Desenvolvedores {get;set;}
    }
}