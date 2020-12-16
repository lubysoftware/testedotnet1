using Api.Model;
using Domain;
using Infrastructure.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LancamentoController : ControllerBase
    {
        private readonly ILogger<LancamentoController> _logger;
        private LancamentoBusiness lancamentoBusiness = new LancamentoBusiness();

        public LancamentoController(ILogger<LancamentoController> logger)
        {
            _logger = logger;
        }

        // GET: api/<LancamentoController>
        [HttpGet]
        public string Get()
        {
            var Lancamento = lancamentoBusiness.GetAll();
            var model = new List<LancamentoModel>();

            foreach (var l in Lancamento)
            {
                var newL = new LancamentoModel();
                newL.Id = l.Id;
                newL.DataFim =l.DataFim;
                newL.DataInicio = l.DataInicio;
                newL.IdDesenvolvedor = l.IdDesenvolvedor;                

                model.Add(newL);
            }

            var json = JsonSerializer.Serialize(model);
            return json;
        }

        // GET api/<LancamentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var lancamento = lancamentoBusiness.GetAllById(id);
            var json = string.Empty;

            if (lancamento != null)
            {
                var newModel = new LancamentoModel();
                newModel.Id = lancamento.Id;
                newModel.DataFim = lancamento.DataFim;
                newModel.DataInicio = lancamento.DataInicio;
                newModel.IdDesenvolvedor = lancamento.IdDesenvolvedor;

                json = JsonSerializer.Serialize(newModel);
            }

            return json;
        }

        // POST api/<LancamentoController>
        /// <summary>
        /// Post API Value
        /// </summary>
        /// <param name="DataFim"></param>
        /// <param name="DataInicio"></param>
        /// <param name="IdDesenvolvedor"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {
            var model = JsonSerializer.Deserialize<LancamentoModel>(value.ToString());

            var newLancamento = new Lancamento();
            newLancamento.DataFim = model.DataFim;
            newLancamento.DataInicio = model.DataInicio;
            newLancamento.IdDesenvolvedor = model.IdDesenvolvedor;

            if (lancamentoBusiness.Add(newLancamento) != null)            
                return "Sucesso";
            
            return "Falha";

        }

        // PUT api/<LancamentoController>/5
        /// <summary>
        /// Put API Value
        /// </summary>
        /// <param name="DataFim"></param>
        /// <param name="DataInicio"></param>
        /// <param name="IdDesenvolvedor"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JsonElement value)
        {
            var lancamento = lancamentoBusiness.GetAllById(id);
            var model = JsonSerializer.Deserialize<LancamentoModel>(value.ToString());

            lancamento.Id = model.Id;
            lancamento.DataFim = model.DataFim;
            lancamento.DataInicio = model.DataInicio;
            lancamento.IdDesenvolvedor = model.IdDesenvolvedor;
                        
            if (lancamentoBusiness.Update(lancamento) != null)            
                return "Sucesso";
            
            return "Falha";
        }

        // DELETE api/<LancamentoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var Lancamento = lancamentoBusiness.GetAllById(id);

            if (Lancamento != null)
            {
                lancamentoBusiness.Delete(Lancamento);
                return "Sucesso";
            }            
            return "Falha";
        }        
    }
}
