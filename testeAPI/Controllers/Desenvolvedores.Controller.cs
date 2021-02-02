using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Models;
using TesteApi.Data;



namespace TesteApi.Controllers
{
    [Produces ("application/json")]
    [Route ("api/Desenvolvedores")]
    public class DesenvolvedoresController : ControllerBase
    {
       private readonly TesteApiContext _context;

       public DesenvolvedoresController (TesteApiContext context)
       {
           _context = context;
       }

        // GET: api/Desenvolvedores
        public IEnumerable<Desenvolvedor> Get () {
            return _context.Desenvolvedores.ToList();
        }


        // POST: api/Desenvolvedores
        [HttpPost]
        public IActionResult Post ([FromBody] Desenvolvedor desenvolvedor)
        {
            if(desenvolvedor.Nome == null)
                return NotFound();

            _context.Desenvolvedores.Add (desenvolvedor);
            _context.SaveChanges(); 
            return NoContent();      
        }

    }


}