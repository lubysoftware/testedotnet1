using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LH001.Contexto;
using LH001.Domain.Entidades;
using LH001.Domain.Api.v1;
using Microsoft.Extensions.Configuration;

namespace LH001.Pages.Desenvolvedor
{
    public class AdicionarModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public Tb_Desenvolvedor modal { get; set; }
        public AdicionarModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult OnGet()
        {
            modal = new Tb_Desenvolvedor();
            return Page();
        }

        [BindProperty]
        public Tb_Desenvolvedor Tb_Desenvolvedor { get; set; }

        public async Task<IActionResult> OnGetAdicionar(string nome)
        {
            var r = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Incluir(nome);
            if (r == "200")
                return RedirectToPage("Index");
            else
            {
                modal = new Tb_Desenvolvedor();
                modal.Nome = nome;
            }
            return Page();
        }
    }
}
