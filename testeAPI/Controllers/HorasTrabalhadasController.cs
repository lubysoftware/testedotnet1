using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Models;
using TesteApi.Data;
using Microsoft.EntityFrameworkCore;


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

        // GET: api/HorasTrabalhadas/top5
        [HttpGet, Route("top5")]
        public IEnumerable<HoraTrabalhada> getTop5()
        {

            var top5 = _context.HorasTrabalhadas
                        .Include(e => e.Projeto)
                        .Include(e => e.Desenvolvedor)
                        .ToList();

            return top5;
        }

        /* NOTETIONS!
        Take(N) - O operador Take é usado para selecionar os primeiros N objetos de uma coleção.
        Skip(N) - O operador Skip ignora o(s) primeiro(s) N objetos de uma coleção.
        */
        


    }

}