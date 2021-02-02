using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiLuby.Context;
using Microsoft.EntityFrameworkCore;
using apiLuby.Models;

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
        public async Task<IActionResult> GetAll()
        {
            var res = await developerContext.ToListAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Developer d)
        {
            await developerContext.AddAsync(d);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
