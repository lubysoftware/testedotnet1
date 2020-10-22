using LubySoftware.Authentication.Models;
using LubySoftware.Authentication.Services;
using LubySoftware.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LubySoftware.Authentication.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly AuthenticationService AuthenticationService;

        public AuthenticationController()
        {
            AuthenticationService = new AuthenticationService();
        }

        [HttpPost]
        public ReturnModel<JwtTokenModel> Post(UserModel user)
        {
            ReturnModel<JwtTokenModel> jwtToken = new ReturnModel<JwtTokenModel>();

            try
            {
                jwtToken.Object = AuthenticationService.Authentication(user);
            }
            catch (Exception ex)
            {
                jwtToken.IsError = true;
                jwtToken.MessageError = ex.Message;
                jwtToken.DetailsError = ex.ToString();
            }

            return jwtToken;
        }
    }
}
