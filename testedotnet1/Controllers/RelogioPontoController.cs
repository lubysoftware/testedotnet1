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
            var existe = _contexto.Relogio_Ponto.ToList();
            if(existe != null)
                return existe;
            else
                return null;
        }

        
        [HttpGet("{id}")]
        public Relogio_Ponto Get(int id)
        {
            var relogioPonto = _contexto.Relogio_Ponto.FirstOrDefault(d => d.Id == id);
            return relogioPonto;
        }

        //LANÇAMENTO DE HORA
        [HttpPost]
        public void Post([FromBody]int idDesenvolvedor, DateTime hora_entrada, DateTime hora_saida)
        {
            _contexto.Relogio_Ponto.Add(new Relogio_Ponto()
            {
                Id_Desenvolvedor = idDesenvolvedor,
                entrada = hora_entrada,
                saida = hora_saida
            });
        }

       
        [HttpPut("{id}")]
        public void Put([FromBody]Relogio_Ponto relogioPonto)
        {
            _contexto.Entry(relogioPonto).State = EntityState.Modified;
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var relogioPonto = _contexto.Relogio_Ponto.FirstOrDefault(d => d.Id == id);
            _contexto.Remove(relogioPonto);
        }
    }
}
