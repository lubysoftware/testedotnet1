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
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
            var developer = await developerContext.FindAsync(id);
            return Ok(developer);
        }

        [HttpPost]
        public async Task<IActionResult> PostDeveloper([FromBody] Developer developer)
        {
            await developerContext.AddAsync(developer);
            await context.SaveChangesAsync();
            return Ok(developer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Developer>> PutDeveloper(int id, [FromBody]Developer developer)
        {
            if (developer.Id != id)
            {
                return BadRequest();
            }

            context.Entry(developer).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return Ok(developer);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Developer>> DeleteDeveloper(int id)
        {
            var developer = await developerContext.FindAsync(id);

            if(developer == null)
            {
                return NotFound();
            }

            developerContext.Remove(developer);
            await context.SaveChangesAsync();
            return Ok(developer);
        }
    }
}
