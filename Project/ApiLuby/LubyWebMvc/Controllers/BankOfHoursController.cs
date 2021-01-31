using LubyWebMvc.Models.BankOfHours;
using LubyWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubyWebMvc.Controllers
{
    public class BankOfHoursController : Controller
    {
        private readonly IBankService _bankService;

        public BankOfHoursController(IBankService bankService)
        {
            _bankService = bankService;
        }

        public IActionResult LaunchHours()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LaunchHours(LaunchHoursInputViewModel launchHoursInputViewModel)
        {
            try
            {
                var launchHours = await _bankService.Launch(launchHoursInputViewModel);
                ModelState.AddModelError("", $"A horas foram lançadas com sucesso, {launchHours.TotalHours} horas");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View();
        }

        public IActionResult GetHours()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetHours(GetHoursOutputViewModel getHoursOutputViewModel)
        {

            return View();
        }

        public IActionResult GetRank()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRank(GetRankOutputViewModel getRankOutputViewModel)
        {

            return View();
        }

    }
}
