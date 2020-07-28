using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Services.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository developerRepository;
        public DeveloperController(IDeveloperRepository deveRepo) => developerRepository = deveRepo;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Developer dev)
        {
            try
            {
                await developerRepository.Create(dev);
                return Created(String.Empty, dev);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não realizado");
            }
        }

        [HttpGet]
        [Route("{identifier}")]
        public async Task<IActionResult> Get(string identifier)
        {
            try
            {
                Developer dev = await developerRepository.Get(identifier);
                return Ok(dev);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não localizado");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Developer dev)
        {
            try
            {
                await developerRepository.Update(dev);
                return Accepted();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não atualizado");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Developer> devs = await developerRepository.List();
            return Ok(devs);
        }
    }
}
