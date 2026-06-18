using AutoMapper;
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.Base;
using Hours.Application.DataContract.Response.User;
using Hours.Domain.DTO;
using Hours.Domain.Interfaces.Services.User;
using System.Threading.Tasks;
using User.Application.Interface;

namespace Login.Application.Application
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IMapper _mapper;
        private readonly ILoginService _LoginService;

        public LoginApplication(IMapper mapper, ILoginService LoginServices
            )
        {
            _mapper = mapper;
            _LoginService = LoginServices;
        }      

        public async Task<Response<object>> FindByLoginAsync(LoginResponse data)
        {
            var response = new Response();

            var result = _mapper.Map<LoginDTO>(data);

            var res = await _LoginService.FindByLoginAsync(result);
            if (res == null)
                 response.Reports.Add(new Reports { Code = "Email", Message = "Email does not exist." });
         
            return new Response<object>(res, response.Reports);
        }       
    }
}