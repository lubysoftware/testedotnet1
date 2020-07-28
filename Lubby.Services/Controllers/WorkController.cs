using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using Lubby.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Services.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository workRepository;
        public WorkController(IWorkRepository workRepo) => workRepository = workRepo;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Work work)
        {
            try
            {
                await workRepository.Create(work);
                return Created(String.Empty, work);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não realizado");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                List<WorkViewModel> dev = await workRepository.List();
                return Ok(dev);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não localizado");
            }
        }
    }
}
