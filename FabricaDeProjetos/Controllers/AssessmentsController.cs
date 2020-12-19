using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FabricaDeProjetos.Domain.Entities;
using Core.ViewModels;

namespace FabricaDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentsCore _core;

        public AssessmentsController(IAssessmentsCore core)
        {
            _core = core;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAssessmentsByProject")]
        public IEnumerable<Assessments> GetAssessmentsByProject(int idProject)
        {
            return _core.GetAssessmentsByProject(idProject);
        }

        [HttpPost]
        [Authorize]
        [Route("AddAssessments")]
        public IActionResult AddAssessments([FromBody] AssessmentsViewModel assessments)
        {
            try
            {
                object ret = _core.AddAssessments(assessments);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar a avaliação.");
            }
        }
    }
}
