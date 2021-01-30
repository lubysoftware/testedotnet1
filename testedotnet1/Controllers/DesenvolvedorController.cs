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
    [ApiController]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly Contexto _contexto;

        public DesenvolvedorController(Contexto contexto)
        {
            _contexto = contexto;          
        }

       
        [HttpGet]
        public IEnumerable<Desenvolvedor> Get()
        {
            return _contexto.Desenvolvedor.ToList();            
        }

       
        [HttpGet("{id}")]
        public Desenvolvedor Get(int id)
        {
            var desenvolvedor = _contexto.Desenvolvedor.FirstOrDefault(d => d.Id == id);
            return desenvolvedor;
        }


        [HttpPost]
        public void Post([FromBody] Desenvolvedor desenvolvedor)
        {
            _contexto.Desenvolvedor.Add(desenvolvedor);
            _contexto.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Desenvolvedor desenvolvedor)
        {
            var existe = _contexto.Desenvolvedor.FirstOrDefault(d => d.Id == id);
            existe.Nome = desenvolvedor.Nome;
            _contexto.SaveChanges();
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var desenvolvedor = _contexto.Desenvolvedor.FirstOrDefault(d => d.Id == id);
            _contexto.Remove(desenvolvedor);
            _contexto.SaveChanges();
        }

       
       
    }
}
