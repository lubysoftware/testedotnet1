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
    public class LoginController : FabricaDeProjetosControllerBase
    {
        private readonly IDeveloperCore _core;

        public LoginController(IDeveloperCore core, IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetLogin")]
        [AllowAnonymous]
        public Developer GetLogin(string email)
        {
            Developer user = _core.GetLogin(email);

            return user;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public object LoginDeveloper([FromBody] Login developer)
        {
            if (developer == null) return BadRequest();
            return _core.LoginDeveloper(developer);
        }
    }
}
