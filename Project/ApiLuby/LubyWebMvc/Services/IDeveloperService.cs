using LubyWebMvc.Models.Developers;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyWebMvc.Services
{
    public interface IDeveloperService
    {
        [Post("/api/v1/developer/register")]
        Task<RegisterDeveloperViewModelInput> Register(RegisterDeveloperViewModelInput registerDeveloperViewModelInput);

        [Post("/api/v1/developer/login")]
        Task<LoginViewModelOutput> Login(LoginViewModelInput loginViewModelInput);
    }
}
