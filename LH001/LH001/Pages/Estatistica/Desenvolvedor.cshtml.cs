using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Domain.Api.v1;
using LH001.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LH001.Pages.Estatistica
{
    public class DesenvolvedorModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public DesenvolvedorModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public List<Tb_Desenvolvedor_Projeto> modalResult { get; set; }
        public async Task<IActionResult> OnGet()
        {
            modalResult = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).EstatisticaPorDesenvolvedor();
            return Page();
        }
    }
}
