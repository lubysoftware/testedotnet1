using Hours.Application.DataContract.Request.User;
using Hours.Application.DataContract.Response.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.Application.Interface;

namespace User.API.Controllers.V1
{
    [Route("v1/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _UserApplication;

        public UserController(IUserApplication UserApplication)
        {
            _UserApplication = UserApplication;
        }

        /// <summary>
        /// Search all time records
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _UserApplication.GetAllAsync();

            return Ok(response.Data);
        }

        /// <summary>
        ///Search with parameters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize("Bearer")]
        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] UserFilterRequest filters)
        {
            var response = await _UserApplication.GetAsync(filters);
            if (response.Data == null)
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
            //if (id == Guid.Empty)
            //    return BadRequest(new Reports { Code = "Id", Message = erro.ErrorMessage });

            var response = await _UserApplication.GetByIdAsync(id);
            if (response.Data == null)
                return NoContent();
         

            return Ok(response.Data);
        }

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult> Save([FromBody] UserGeneralRequest data)
        {
            var response = await _UserApplication.SaveAsync(data);

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
        public async Task<ActionResult> Update([FromBody] UserRequest data)
        {
            var response = await _UserApplication.UpdateAsync(data);

            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Authorize("Bearer")]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromHeader] Guid id)
        {
            var response = await _UserApplication.DeleteAsync(id);
            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }
    }
}
