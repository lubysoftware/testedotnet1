using LancamentoHorasAPI.Dto;
using LancamentoHorasAPI.Interfaces;
using LancamentoHorasAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Services
{
    public class DesenvolvedoresService : IDesenvolvedorService
    {
        private readonly ApplicationContext _context;

        public DesenvolvedoresService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Desenvolvedor>> FindAllAsync()
        {
            return await _context.Desenvolvedores.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Desenvolvedor> FindByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido");

            return await _context.Desenvolvedores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Desenvolvedor desenvolvedor)
        {
            if (desenvolvedor == null)
                throw new NotFoundException("Desenvolvedor inválido");

            try
            {
                _context.Update(desenvolvedor);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task InsertAsync(DesenvolvedorPost desenvolvedorPost)
        {
            if (desenvolvedorPost == null)
                throw new NotFoundException("Desenvolvedor inválido");

            try
            {
                var desenvolvedor = new Desenvolvedor()
                {
                    Nome = desenvolvedorPost.Nome,
                };

                _context.Add(desenvolvedor);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }

        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido");

            var desenvolvedor =await FindByIdAsync(id);

            try
            {
                _context.Remove(desenvolvedor);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<IEnumerable<DesenvolvedorRankResult>> GetTop5Async()
        {
            var desenvolvedores = _context.Lancamentos
                .Include(l => l.Desenvolvedor)
                .GroupBy(d => new { d.Desenvolvedor.Nome, d.DesenvolvedorId })
                .Select(s => new DesenvolvedorRankResult
                {
                    DesenvolvedorId = s.Key.DesenvolvedorId,
                    Nome = s.Key.Nome,
                    HorasTrabalhadas = TimeSpan.FromSeconds(s.Sum(w => (w.DataFim - w.DataInicio).TotalSeconds))
                })
                .OrderByDescending(d => d.HorasTrabalhadas)
                .Take(5);
            return desenvolvedores;
        }
    }
}
