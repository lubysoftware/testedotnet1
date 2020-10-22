using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.RegisterHours.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        readonly RegisterService RegisterService;

        public RegisterController(IRegisterHoursRepository registerHoursRepository)
        {
            RegisterService = new RegisterService(registerHoursRepository);
        }

        [HttpPost]
        public async Task Post(RegisterHourModel registerHour)
        {
            await RegisterService.Save(registerHour);
        }

        [HttpGet("{id}")]
        public async Task<RegisterHourModel> Get(long id)
        {
            return await RegisterService.Find(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await RegisterService.Delete(id);
        }

        [HttpPut]
        public async Task Put(RegisterHourModel registerHour)
        {
            await RegisterService.Update(registerHour);
        }
    }
}
