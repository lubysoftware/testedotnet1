using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gerenciador_de_horas_de_desenvolvedores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        

        private readonly ILogger<LubyTestDB> logger;
private LubyTestDB context;
        public DesenvolvedorController(ILogger<LubyTestDB> _logger, LubyTestDB _context)
        {

            logger = _logger;
            context = _context;
        }

        [HttpGet]
        public string Get()
        {
            context.Desenvolvedores.Add( new DesenvolvedorTable() {
                Nome = "Daniel",
                Cargo = "FullStack c# - Angular",
                ValorH = 17.0
            });
            var res = context.SaveChanges();
            return res.ToString();
        }
    }
}
