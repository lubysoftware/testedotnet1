using System;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Domain.Interfaces;
using PontoAPI.Domain.Models;
using Newtonsoft.Json;

namespace PontoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository projetoRepository;

        public ProjetoController(IProjetoRepository projRepository)
        {
            projetoRepository = projRepository;
        }

        [HttpPost, Route("Create")]
        public bool Create([FromBody] Projeto projeto)
        {
            try
            {
                projetoRepository.CreateProjeto(projeto);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpGet, Route("GetProjeto/{projetoID}")]
        public string GetProjeto(int projetoID)
        {
            try
            {
                var projeto = projetoRepository.GetProjeto(projetoID);
                return JsonConvert.SerializeObject(projeto);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpDelete, Route("DeleteProjeto/{projetoID}")]
        public bool DeleteProjeto(int projetoID)
        {
            try
            {
                projetoRepository.DeleteProjeto(projetoID);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpPut, Route("EditProjeto")]
        public bool EditProjeto([FromBody] Projeto projeto)
        {
            try
            {
                projetoRepository.EditProjeto(projeto);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}