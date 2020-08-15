using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Services
{
    public class RegistroDeHorasService
    {
        private readonly LancadorContext _context;

        public RegistroDeHorasService(LancadorContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeHoras>> Get() => await _context.RegistrosDeHoras.ToListAsync();

        public async Task<RegistroDeHoras> GetById(int? id) => await _context.RegistrosDeHoras.FindAsync(id);

        public async Task<RegistroDeHoras> Update(int id, RegistroDeHoras registroDeHorasIn)
        {
            _context.Entry(registroDeHorasIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroDeHorasExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return registroDeHorasIn;
        }

        public async Task Create(RegistroDeHoras registroDeHorasIn)
        {
            _context.RegistrosDeHoras.Add(registroDeHorasIn);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(RegistroDeHoras registroDeHoras)
        {
            _context.RegistrosDeHoras.Remove(registroDeHoras);
            await _context.SaveChangesAsync();
        }

        private bool RegistroDeHorasExists(int id)
        {
            return _context.RegistrosDeHoras.Any(e => e.Id == id);
        }
    }
}