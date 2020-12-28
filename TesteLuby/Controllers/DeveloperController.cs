using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<DeveloperDTO> Get(int id)
        {
            try
            {
                var data = _developerService.Get(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getbyname/{name}")]
        [HttpGet]
        public ActionResult<IEnumerable<DeveloperDTO>> GetByName(string name)
        {
            try
            {
                var data = _developerService.GetByName(name);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("save")]
        [HttpPost]
        public ActionResult Save(DeveloperDTO developerDTO)
        {
            try
            {
                if (_developerService.Insert(developerDTO))
                    return Ok("Salvo com sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o desenvolvedor. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("edit/{id}")]
        [HttpPut]
        public ActionResult Edit(DeveloperDTO developerDTO,  int id)
        {
            try
            {
                if(_developerService.Update(developerDTO, id))
                    return Ok("Atualizado com Sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o desenvolvedor. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
