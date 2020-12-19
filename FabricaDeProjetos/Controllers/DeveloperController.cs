using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FabricaDeProjetos.Controllers.Base;
using FabricaDeProjetos.Domain.Entities;
using Core.Core;
using Core.ViewModels;

namespace FabricaDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : FabricaDeProjetosControllerBase
    {
        private readonly IDeveloperCore _core;

        public DeveloperController(IDeveloperCore core,IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Authorize]
        [Route("GetLogin")]
        public Developer GetDeveloperByEmail(string email)
        {
            Developer user = _core.GetDeveloperByEmail(email);

            return user;
        }

        [HttpGet]
        [Authorize]
        [Route("GetDeveloperById")]
        public IEnumerable<Developer> GetDeveloperById(int id)
        {
            return _core.GetDeveloperById(id);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public object LoginDeveloper([FromBody] Developer developer)
        {
            if (developer == null) return BadRequest();
            return _core.LoginDeveloper(developer);
        }

        [HttpPost]
        [Route("AddDeveloper")]
        [AllowAnonymous]
        public IActionResult AddDeveloper([FromBody] DeveloperViewModel developer)
        {
            try
            {
                object ret = _core.AddDeveloper(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o cliente.");
            }
        }

        [HttpPut]
        [Route("AddDeveloper")]
        [AllowAnonymous]
        public IActionResult UpdateDeveloper([FromBody] DeveloperViewModel developer)
        {
            try
            {
                object ret = _core.UpdateDeveloper(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível modificar o cliente.");
            }
        }

        [HttpDelete]
        [Route("AddDeveloper")]
        [AllowAnonymous]
        public IActionResult DeleteDeveloper([FromBody] DeveloperViewModel developer)
        {
            try
            {
                object ret = _core.DeleteDeveloper(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível deletar  o cliente.");
            }
        }
    }
}
