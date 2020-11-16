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
    public class LancamentoController : Controller
    {
        private readonly ILancamentoRepository lancamentoRepository;

        public LancamentoController(ILancamentoRepository lancRepository)
        {
            lancamentoRepository = lancRepository;
        }

        [HttpPost, Route("Create")]
        public bool CreateLancamento(Lancamento lancamento)
        {
            try
            {
                lancamento.HoraInicio = DateTime.Now;
                lancamentoRepository.Create(lancamento);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("GetLancamentos")]
        public string GetLancamentos()
        {
            try
            {
                var lancamentos = lancamentoRepository.GetLancamentos();
                return JsonConvert.SerializeObject(lancamentos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("Ranking")]
        public string RankingSemanal()
        {
            try
            {
                return string.Empty;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}