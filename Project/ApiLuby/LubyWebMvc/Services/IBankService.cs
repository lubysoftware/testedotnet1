using LubyWebMvc.Models.BankOfHours;
using LubyWebMvc.Models.Developers;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyWebMvc.Services
{
    public interface IBankService
    {
        [Post("/api/v1/bankofhours/")]
        [Headers("Authorization: Bearer")]
        Task<LaunchHoursOutputViewModel> Launch(LaunchHoursInputViewModel launchHoursInputViewModel);

       // [Post("/api/v1/developer/login")]
       // Task<LoginViewModelOutput> Login(LoginViewModelInput loginViewModelInput);
    }
}
