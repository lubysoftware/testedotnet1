using Hours.Application.DataContract.Request.User;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _UserApplication.GetAllAsync();

            return Ok(response.Data);
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromHeader] UserFilterRequest filters)
        {
            var response = await _UserApplication.GetAsync(filters);

            return Ok(response.Data);
        }
      

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _UserApplication.GetByIdAsync(id);
            if (response == null)
                return BadRequest();

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody] UserRequest data)
        {
            var response = await _UserApplication.SaveAsync(data);

            if (response.Reports.Count > 0)
                return Ok(response.Reports);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserRequest data)
        {
            var response = await _UserApplication.UpdateAsync(data);

            if (response.Reports.Count > 0)
                return Ok(response.Reports);

            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromHeader] Guid id)
        {
            var response = await _UserApplication.DeleteAsync(id);

            return Ok(response);
        }
    }
}
