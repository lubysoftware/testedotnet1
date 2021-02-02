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
    public class ProjectsController : ControllerBase
    {
        private readonly MSSQLContext context;

        private DbSet<Project> projectContext;

        public ProjectsController(MSSQLContext context)
        {
            this.context = context;
            this.projectContext = this.context.Set<Project>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var res = await projectContext.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await projectContext.FindAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            await projectContext.AddAsync(project);
            await context.SaveChangesAsync();
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> PutProject(int id, [FromBody]Project project)
        {
            if (project.Id != id)
            {
                return BadRequest();
            }

            context.Entry(project).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return Ok(project);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await projectContext.FindAsync(id);

            if(project == null)
            {
                return NotFound();
            }

            projectContext.Remove(project);
            await context.SaveChangesAsync();
            return Ok(project);
        }
    }
}
