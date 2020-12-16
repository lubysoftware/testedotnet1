using Api.Model;
using Infrastructure.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DesenvolvedorController : ControllerBase
    {
        private readonly ILogger<DesenvolvedorController> _logger;
        private DesenvolvedorBusiness desenvolvedorBusiness = new DesenvolvedorBusiness();
        private LancamentoBusiness lancamentoBusiness = new LancamentoBusiness();

        public DesenvolvedorController(ILogger<DesenvolvedorController> logger)
        {
            _logger = logger;
        }

        // GET: api/<DesenvolvedorController>
        [HttpGet]
        public string Get()
        {
            var desenvolvedor = desenvolvedorBusiness.GetAll();
            var model = new List<DesenvolvedorModel>();

            foreach (var d in desenvolvedor)
            {   
                var newD = new DesenvolvedorModel();
                newD.Id = d.Id;
                newD.Nome = d.Nome;

                model.Add(newD);
            }

            var json = JsonSerializer.Serialize(model);          
            return json;
        }

        // GET api/<DesenvolvedorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var desenvolvedor = desenvolvedorBusiness.GetAllById(id);
            var json = string.Empty;

            if (desenvolvedor != null)
            {
                var newModel = new DesenvolvedorModel();
                newModel.Id = desenvolvedor.Id;
                newModel.Nome = desenvolvedor.Nome;

                json = JsonSerializer.Serialize(newModel);
            }

            return json;
        }

        // POST api/<DesenvolvedorController>
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {            
            var model = JsonSerializer.Deserialize<DesenvolvedorModel>(value.ToString());

            var newDesenvolvedor = new Desenvolvedor();
            newDesenvolvedor.Nome = model.Nome;

            if (desenvolvedorBusiness.Add(newDesenvolvedor) != null)            
                return "Sucesso";

            return "Falha";
        }

        // PUT api/<DesenvolvedorController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JsonElement value)
        {
            var desenvolvedor = desenvolvedorBusiness.GetAllById(id);
            var model = JsonSerializer.Deserialize<DesenvolvedorModel>(value.ToString());

            desenvolvedor.Nome = model.Nome;

            if(desenvolvedorBusiness.Update(desenvolvedor) != null)
                return "Sucesso";

            return "Falha";
        }

        // DELETE api/<DesenvolvedorController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var desenvolvedor = desenvolvedorBusiness.GetAllById(id);

            if (desenvolvedor != null)
            {
                desenvolvedorBusiness.Delete(desenvolvedor);
                var lsLancamento = lancamentoBusiness.GetAll().Where(x => x.IdDesenvolvedor == desenvolvedor.Id);
                foreach (var item in lsLancamento)
                    lancamentoBusiness.Delete(item);                      

                return "Sucesso";
            }
            return "Falha";
        }
    }
}
