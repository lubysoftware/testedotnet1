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
            var existe = _contexto.Desenvolvedor.ToList();
            if (existe != null)
                return existe;
            else
                return null;
        }

       
        [HttpGet("{id}")]
        public Desenvolvedor Get(int id)
        {
            var desenvolvedor = _contexto.Desenvolvedor.FirstOrDefault(d => d.Id == id);
            return desenvolvedor;
        }


        
        public string Post(string desenvolvedor)
        {
            try
            {
                _contexto.Desenvolvedor.Add(new Desenvolvedor(desenvolvedor));
                return "sucesso";
            }
            catch(Exception)
            {
                return "Falhou";
            }
            
        }

        
        [HttpPut]
        public void Put([FromBody]Desenvolvedor desenvolvedor)
        {
            _contexto.Entry(desenvolvedor).State = EntityState.Modified;
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var desenvolvedor = _contexto.Desenvolvedor.FirstOrDefault(d => d.Id == id);
            _contexto.Remove(desenvolvedor);
        }
    }
}
