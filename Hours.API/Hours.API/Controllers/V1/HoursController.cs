using Hours.Application.DataContract.Request.Hours;
using Hours.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Search all time records
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize("Bearer")]
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _hoursApplication.GetAllAsync();
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

        /// <summary>
        ///Search with parameters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize("Bearer")]
        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] HoursFilterRequest filters)
        {
            var response = await _hoursApplication.GetAsync(filters);
            if (response == null)
                return NoContent();

            return Ok(response.Data);
        }

        /// <summary>
        ///Search for the top 5 ranking of the developers who worked the most this week
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize("Bearer")]
        [HttpGet("GetRankingDevs")]
        public async Task<ActionResult> GetRankingDevs()
        {
            var response = await _hoursApplication.GetRankingDevsAsync();
            if (response == null)
                return NoContent();

            return Ok(response.Data);
        }

        /// <summary>
        ///Fetch an object according to the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize("Bearer")]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _hoursApplication.GetByIdAsync(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

        /// <summary>
        ///Post save Hours
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult> Save([FromBody] HoursGeneralRequest data)
        {
            var response = await _hoursApplication.SaveAsync(data);

            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }

        /// <summary>
        ///Post update Hours
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] HoursRequest data)
        {
            var response = await _hoursApplication.UpdateAsync(data);

            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }

        /// <summary>
        /// Delete Hours
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Authorize("Bearer")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _hoursApplication.DeleteAsync(id);

            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }
    }
}
