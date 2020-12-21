using System;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FabricaDeProjetos.Controllers.Base;
using Core.ViewModels;

namespace FabricaDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : FabricaDeProjetosControllerBase
    {
        private readonly IProjectCore _core;

        public DashboardController(IProjectCore core, IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetProjectActive")]
        [AllowAnonymous]
        public IActionResult GetProjectActive()
        {
            var ret = _core.GetProjectActive();
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetProjectNoActive")]
        [AllowAnonymous]
        public IActionResult GetProjectNoActive()
        {
            var ret = _core.GetProjectNoActive();
            return Ok(ret);
        }
    }
}
