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
    public class ProjetoModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public ProjetoModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public List<Tb_Desenvolvedor_Projeto> modalResult { get; set; }
        public async Task<IActionResult> OnGet()
        {
            modalResult = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).EstatisticaPorProjeto();
            return Page();
        }
    }
}
