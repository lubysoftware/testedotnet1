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
    public class ProjetosService : IProjetoService
    {
        private readonly ApplicationContext _context;

        public ProjetosService(ApplicationContext context)
        {
            _context = context;
        }


        public async Task InsertHorasAsync(int projetoId, LancamentoPost lancamentoPost)
        {
            if (lancamentoPost == null)
                throw new ArgumentNullException(nameof(lancamentoPost));


            if (lancamentoPost.DataFim < lancamentoPost.DataInicio)
                throw new ArgumentException("Datas inválidas");

            if (projetoId <= 0)
                throw new ArgumentException("Projeto inválido");


            var lancamento = new Lancamento()
            {
                ProjetoId = projetoId,
                DesenvolvedorId = lancamentoPost.DesenvolvedorId,
                DataFim = lancamentoPost.DataFim,
                DataInicio = lancamentoPost.DataInicio
            };

            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Projeto>> FindAllAsync()
        {
            return await _context.Projetos.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Projeto> FindByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Projeto inválido");

            return await _context.Projetos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            if (projeto == null)
                throw new NotFoundException("Id não encontrado");

            try
            {
                _context.Update(projeto);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task InsertAsync(ProjetoPost projetoPost)
        {
            if (projetoPost == null)
                throw new NotFoundException("Projeto inválido");
            try
            {
                var projeto = new Projeto()
                {
                    Nome = projetoPost.Nome,
                };

                _context.Add(projeto);
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
                throw new NotFoundException("Id não encontrado");

            var projeto =await FindByIdAsync(id);

            try
            {
                _context.Remove(projeto);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
