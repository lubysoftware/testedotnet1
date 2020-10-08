using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LubyPontoEletronico.Controllers
{
    public class PontoController : ControllerBase<Ponto, PontoDTO>
    {
        public PontoController(IPontoApplication app)
          : base(app)
        { }
    }
}
