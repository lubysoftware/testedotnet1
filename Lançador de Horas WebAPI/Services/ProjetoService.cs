using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Services
{
    public class ProjetoService
    {
        private readonly LancadorContext _context;

        public ProjetoService(LancadorContext context)
        {
            _context = context;
        }

        public async Task<List<Projeto>> Get() => await _context.Projetos.ToListAsync();

        public async Task<Projeto> GetById(int id) => await _context.Projetos.FindAsync(id);

        public async Task<Projeto> Update(int id, Projeto projetoIn)
        {
            _context.Entry(projetoIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return projetoIn;
        }

        public async Task Create(Projeto projetoIn)
        {
            _context.Projetos.Add(projetoIn);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Projeto projeto)
        {
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.Id == id);
        }
    }
}