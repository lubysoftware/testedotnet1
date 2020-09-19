using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PontoAPI.Domain.Interfaces;
using PontoAPI.Domain.Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PontoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DesenvolvedorController : Controller
    {
        private readonly IDesenvolvedorRepository desenvolvedorRepository;

        public DesenvolvedorController(IDesenvolvedorRepository devRepository)
        {
            desenvolvedorRepository = devRepository;
        }

        [HttpPost, Route("Create")]
        public bool Create([FromBody] Desenvolvedor desenvolvedor)
        {
            try
            {
                desenvolvedorRepository.CreateDesenvolvedor(desenvolvedor);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet, Route("GetDesenvolvedor/{desenvolvedorID}")]
        public string GetDesenvolvedor(int desenvolvedorID)
        {
            try
            {
                var desenvolvedor = desenvolvedorRepository.GetDesenvolvedor(desenvolvedorID);
                return JsonConvert.SerializeObject(desenvolvedor, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete, Route("DeleteDesenvolvedor/{desenvolvedorID}")]
        public bool DeleteDesenvolvedor(int desenvolvedorID)
        {
            try
            {
                desenvolvedorRepository.DeleteDesenvolvedor(desenvolvedorID);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpPut, Route("EditDesenvolvedor")]
        public bool EditDesenvolvedor([FromBody] Desenvolvedor desenvolvedor)
        {
            try
            {
                desenvolvedorRepository.EditDesenvolvedor(desenvolvedor);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}