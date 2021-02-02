using apiLuby.Context;
using apiLuby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace apiLuby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly MSSQLContext context;

        private DbSet<Developer> developerContext;

        public DevelopersController(MSSQLContext context)
        {
            this.context = context;
            this.developerContext = this.context.Set<Developer>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var res = await developerContext.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(Guid id)
        {
            var dev = await developerContext.FindAsync(id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloper([FromBody] Developer d)
        {
            await developerContext.AddAsync(d);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
