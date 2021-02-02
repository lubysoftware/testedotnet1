using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Models;
using TesteApi.Data;



namespace TesteApi.Controllers
{
    [Produces ("application/json")]
    [Route ("api/Projetos")]
    public class ProjetosController : ControllerBase
    {
       private readonly TesteApiContext _context;

       public ProjetosController (TesteApiContext context)
       {
           _context = context;
       }

        // GET: api/Projetos
        public IEnumerable<Projeto> Get () {
            return _context.Projetos.ToList();
        }


        // POST: api/Projetos
        [HttpPost]
        public IActionResult Post ([FromBody] Projeto projeto)
        {
            if(projeto.Nome == null)
                return NotFound();

            _context.Projetos.Add (projeto);
            _context.SaveChanges(); 
            return NoContent();      
        }

    }


}