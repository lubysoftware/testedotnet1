using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lancamentoHoras.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace lancamentoHoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedorController : ControllerBase
    {
        // GET: api/Desenvolvedor
        [HttpGet]
        [Authorize]
        public async Task<string> Get()
        {
            return await DBQueries.GetDevelopers();
        }

        // GET: api/Desenvolvedor/#
        [HttpGet("{id}")]
        [Authorize]
        public async Task<string> Get(int id)
        {
            return await DBQueries.GetDeveloper(id);
        }

        // POST: api/Desenvolvedor
        [HttpPost]
        [Authorize]
        public async Task<string> Post([FromBody]string nome)
        {
            return await DBQueries.NewDeveloper(nome);
        }

        // PUT: api/Desenvolvedor/#
        [HttpPut("{id}")]
        [Authorize]
        public async Task<string> Put(int id, [FromBody]string nome)
        {
            return await DBQueries.UpdateDeveloper(id, nome);
        }

        // DELETE: api/ApiWithActions/#
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<string> Delete(int id)
        {
            return await DBQueries.DeleteDeveloper(id);
        }
    }
}
