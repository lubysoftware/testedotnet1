using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Models;
using TesteApi.Data;
using Microsoft.EntityFrameworkCore;
using TesteApi.VO;


 namespace TesteApi.Controllers
{
    [Produces("application/json")]
    [Route("api/HorasTrabalhadas")]
    public class HorasTrabalhadasController : ControllerBase
    {
        private readonly TesteApiContext _context;

        public HorasTrabalhadasController(TesteApiContext context)
        {
            _context = context;
        }

        // GET: api/HorasTrabalhadas
        public IEnumerable<HoraTrabalhada> Get()
        {

            return _context.HorasTrabalhadas
                        .Include(e => e.Projeto)
                        .Include(e => e.Desenvolvedor)
                        .ToList();
        }


        // POST: api/HorasTrabalhadas
        [HttpPost]
        public IActionResult Post([FromBody] HoraTrabalhada horaTrabalhada)
        {
            if (horaTrabalhada.DtInicio == null || horaTrabalhada.DtFim == null)
                return NotFound();

            _context.HorasTrabalhadas.Add(horaTrabalhada);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet, Route("top5")]
        public IEnumerable<HoraTrabalhadaVO> top5()
        {
            var result = (from totalHoras in _context.HorasTrabalhadas select new HoraTrabalhada
            {
                Id = totalHoras.Id,
                DesenvolvedorId = totalHoras.DesenvolvedorId,
                ProjetoId = totalHoras.ProjetoId,
                DtInicio = totalHoras.DtInicio,
                DtFim = totalHoras.DtFim,
                Desenvolvedor = (from desenvolvedor in _context.Desenvolvedores 
                                where desenvolvedor.Id == totalHoras.DesenvolvedorId 
                                select new Desenvolvedor{
                                    Id = desenvolvedor.Id,
                                    Nome = desenvolvedor.Nome
                                }).FirstOrDefault(),
                Projeto = (from projeto in _context.Projetos
                            where projeto.Id == totalHoras.ProjetoId
                            select new Projeto{
                                Id = projeto.Id,
                                Nome= projeto.Nome
                            }).FirstOrDefault()


            }).ToList().GroupBy(e => new { e.Desenvolvedor.Nome, e.DesenvolvedorId} )
            .Select( g => new HoraTrabalhadaVO 
            {
                DesenvolvedorId = g.Key.DesenvolvedorId,
                NomeDesenvolvedor = g.Key.Nome,
                TotalHoras = g.Sum(e => e.DtFim.Subtract(e.DtInicio).TotalHours)
            }).OrderByDescending(e => e.TotalHoras)
            .Take(5)
            .ToList();

            return result;
        }
    }

}