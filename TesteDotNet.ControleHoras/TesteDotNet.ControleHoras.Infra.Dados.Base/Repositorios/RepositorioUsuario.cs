using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dados.Base.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        private readonly DbContexto _dbContexto;

        public RepositorioUsuario(DbContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public override bool Exists(int id)
        {
            return _dbContexto.Usuarios.Any(x => x.Id == id);
        }
        
        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbContexto.Usuarios.AnyAsync(x => x.Id == id);
        }

        public Task<Usuario> GetUsuario(string nomeUsuario, string senha)
        {
            var usuarios = new List<Usuario>();
            
            usuarios.Add(new Usuario { Id = 1, NomeUsuario = "admin", Senha = "masterkey", Role = "manager" });
            usuarios.Add(new Usuario { Id = 2, NomeUsuario = "joao", Senha = "abc123", Role = "user" });

            var retorno = usuarios.Where(x => x.NomeUsuario.ToLower() == nomeUsuario.ToLower() && x.Senha == senha).FirstOrDefault();

            return Task.FromResult(retorno);
        }
    }
}
