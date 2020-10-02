using LancamentoHorasAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Services
{
    public class SeedingService
    {
        private readonly ApplicationContext _context;

        public SeedingService(ApplicationContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Projetos.Any())
            {
                return;
            }

            Projeto projeto1 = new Projeto("Luby API");
            Projeto projeto2 = new Projeto("Luby MVC");

            Desenvolvedor desenvolvedor1 = new Desenvolvedor("Gabriel");
            Desenvolvedor desenvolvedor2 = new Desenvolvedor("José");
            Desenvolvedor desenvolvedor3 = new Desenvolvedor("Maria");
            Desenvolvedor desenvolvedor4 = new Desenvolvedor("Camila");
            Desenvolvedor desenvolvedor5 = new Desenvolvedor("Gustavo");

            Lancamento lancamento1 = new Lancamento { DataInicio = new DateTime(2020, 8, 16).AddHours(8), DataFim = new DateTime(2020, 8, 16).AddHours(16), DesenvolvedorId = 1, ProjetoId = 1 };
            Lancamento lancamento2 = new Lancamento { DataInicio = new DateTime(2020, 8, 18).AddHours(8), DataFim = new DateTime(2020, 8, 18).AddHours(8), DesenvolvedorId = 1, ProjetoId = 1 };

            _context.Projetos.AddRange(projeto1, projeto2);
            _context.Desenvolvedores.AddRange(desenvolvedor1, desenvolvedor2, desenvolvedor3, desenvolvedor4, desenvolvedor5);
            _context.Lancamentos.AddRange(lancamento1, lancamento2);
            _context.SaveChanges();
        }
    }
}
