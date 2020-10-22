using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.RegisterHours.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        readonly PersonService PersonService;

        public DeveloperController(IPersonRepository personRepository)
        {
            PersonService = new PersonService(personRepository);
        }

        [HttpPost]
        public async Task Post(PersonModel person)
        {
            await PersonService.Save(person);
        }

        [HttpGet("{id}")]
        public async Task<PersonModel> Get(long id)
        {
            return await PersonService.Find(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await PersonService.Delete(id);
        }

        [HttpPut]
        public async Task Put(PersonModel person)
        {
            await PersonService.Update(person);
        }
    }
}
