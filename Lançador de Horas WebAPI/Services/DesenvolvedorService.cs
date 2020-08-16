using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Services
{
    public class DesenvolvedorService
    {
        private readonly LancadorContext _context;

        public DesenvolvedorService(LancadorContext context)
        {
            _context = context;
        }

        public async Task<List<Desenvolvedor>> Get() => await _context.Desenvolvedores.ToListAsync();

        public async Task<Desenvolvedor> GetById(int id) => await _context.Desenvolvedores.FindAsync(id);

        public async Task<Desenvolvedor> Update(int id, Desenvolvedor desenvolvedorIn)
        {
            _context.Entry(desenvolvedorIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesenvolvedorExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return desenvolvedorIn;
        }

        public async Task Create(Desenvolvedor desenvolvedorIn)
        {
            _context.Desenvolvedores.Add(desenvolvedorIn);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Desenvolvedor desenvolvedor)
        {
            _context.Desenvolvedores.Remove(desenvolvedor);
            await _context.SaveChangesAsync();
        }

        private bool DesenvolvedorExists(int id)
        {
            return _context.Desenvolvedores.Any(e => e.Id == id);
        }
    }
}