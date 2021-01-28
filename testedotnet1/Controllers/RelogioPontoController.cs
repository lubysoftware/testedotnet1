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

        [HttpGet]
        public IEnumerable<Relogio_Ponto> Get()
        {
            return _contexto.tbl_RelogioPonto.ToList();
        }

        
        [HttpGet("{id}")]
        public Relogio_Ponto Get(int id)
        {
            var relogioPonto = _contexto.tbl_RelogioPonto.FirstOrDefault(d => d.Id == id);
            return relogioPonto;
        }

        
        [HttpPost]
        public void Post([FromBody]Relogio_Ponto relogioPonto)
        {
            _contexto.tbl_RelogioPonto.Add(relogioPonto);
        }

       
        [HttpPut("{id}")]
        public void Put([FromBody]Relogio_Ponto relogioPonto)
        {
            _contexto.Entry(relogioPonto).State = EntityState.Modified;
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var relogioPonto = _contexto.tbl_RelogioPonto.FirstOrDefault(d => d.Id == id);
            _contexto.Remove(relogioPonto);
        }
    }
}
