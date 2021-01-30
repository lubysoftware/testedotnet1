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
    public class ProjetoController : Controller
    {
        private readonly Contexto _contexto;

        public ProjetoController(Contexto contexto)
        {
            _contexto = contexto;
        }
       
        [HttpGet]
        public IEnumerable<Projeto> Get()
        {
            return _contexto.Projeto.ToList();            
        }

       
        [HttpGet("{id}")]
        public Projeto Get(int id)
        {
            var projeto = _contexto.Projeto.FirstOrDefault(d => d.Id == id);
            return projeto;
        }

        
        [HttpPost]
        public void Post([FromBody]Projeto projeto)
        {
            _contexto.Projeto.Add(projeto);
            _contexto.SaveChanges();
        }

       
        [HttpPut("{id}")]
        public void Put(int id,[FromBody]Projeto projeto)
        {
            var existe = _contexto.Projeto.FirstOrDefault(d => d.Id == id);
            existe.Nome = projeto.Nome;
            _contexto.SaveChanges();
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var projeto = _contexto.Projeto.FirstOrDefault(d => d.Id == id);
            _contexto.Remove(projeto);
            _contexto.SaveChanges();
        }
    }
}
