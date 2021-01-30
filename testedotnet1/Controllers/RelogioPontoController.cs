using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Models;

namespace testedotnet1.Controllers
{
    [Route("api/[controller]")]
    public class RelogioPontoController : Controller
    {
        private readonly Contexto _contexto;

        public RelogioPontoController(Contexto contexto)
        {
            _contexto = contexto;
        }

       
        //LANÇAMENTO DE HORA
        [HttpPost]
        public void Post([FromBody]Relogio_Ponto relogioPonto)
        {
            _contexto.Relogio_Ponto.Add(relogioPonto);            
            _contexto.SaveChanges();
        }
       

        [HttpGet]
        public IEnumerable<Desenvolvedor> GetRankingDesenvolvedores()
        {
            var devlist = _contexto.Desenvolvedor.ToList();
            var horarioslist = _contexto.Relogio_Ponto.ToList();

            IEnumerable<Desenvolvedor> query = (from d in devlist
                                                join h in horarioslist on d.Id equals h.Id_Desenvolvedor
                                                orderby (h.saida - h.entrada) descending
                                                select d).Take(5);

            return query;
        }
    }
}
