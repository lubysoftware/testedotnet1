using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lancamentoHoras.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace lancamentoHoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        // GET: api/Projeto
        [HttpGet]
        [Authorize]
        public async Task<string> Get()
        {
            return await DBQueries.GetProjects();
        }

        // GET: api/Projeto/#
        [HttpGet("{id}")]
        [Authorize]
        public async Task<string> Get(int id)
        {
            return await DBQueries.GetProject(id);
        }

        // POST: api/Projeto
        [HttpPost]
        [Authorize]
        public async Task<string> Post([FromForm] string nome, [FromForm] int responsavel)
        {
            return await DBQueries.NewProject(nome, responsavel);
        }

        // PUT: api/Projeto/#
        [HttpPut("{id}")]
        [Authorize]
        public async Task<string> Put(int id, [FromForm] string nome, [FromForm] int? responsavel)
        {
            return await DBQueries.UpdateProject(id, nome, responsavel);
        }

        // DELETE: api/Projeto/#
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<string> Delete(int id)
        {
            return await DBQueries.DeleteProject(id);
        }
    }
}
