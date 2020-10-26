using Hours.Application.DataContract.Request;
using Hours.Application.DataContract.Request.Hours;
using Hours.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hours.API.Controllers.V1
{
    [Route("v1/hours")]
    [ApiController]
    public class HoursController : ControllerBase
    {
        private readonly IHoursApplication _hoursApplication;

        public HoursController(IHoursApplication hoursApplication)
        {
            _hoursApplication = hoursApplication;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _hoursApplication.GetAllAsync();

            return Ok(response.Data);
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromHeader] HoursFilterRequest filters)
        {
            var response = await _hoursApplication.GetAsync(filters);

            return Ok(response.Data);
        }

        [HttpGet("GetRankingDevs")]
        public async Task<ActionResult> GetRankingDevs()
        {
            var response = await _hoursApplication.GetRankingDevsAsync();

            return Ok(response.Data);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _hoursApplication.GetByIdAsync(id);
            if (response == null)
                return BadRequest();

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody] HoursRequest data)
        {
            var response = await _hoursApplication.SaveAsync(data);

            if (response.Reports.Count > 0)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] HoursRequest data)
        {
            var response = await _hoursApplication.UpdateAsync(data);

            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromHeader] Guid id)
        {
            var response = await _hoursApplication.DeleteAsync(id);

            return Ok(response);
        }
    }
}
