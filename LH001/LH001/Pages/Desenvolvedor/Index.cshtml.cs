using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Domain.Api.v1;
using LH001.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LH001.Pages.Desenvolvedor
{

    public class IndexModel : PageModel
    {
        [BindProperty]
        public Tb_Desenvolvedor modalBusca { get; set; }

        [BindProperty]
        public List<Tb_Desenvolvedor> modalResult { get; set; }

        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGet()
        {
            modalResult = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Listar();
            modalBusca = new Tb_Desenvolvedor();
            return Page();
        }

        public async Task<IActionResult> OnGetBuscar(int id, string nome)
        {
            if (nome == null && id == 0)
                modalResult = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Listar();
            else
            {
                modalBusca = new Tb_Desenvolvedor();
                modalBusca.Id = id;
                modalBusca.Nome = nome;
                modalResult = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Buscar(id, nome);
            }
            //return RedirectToPage("Index");
            return new JsonResult(new { ok = true, result = modalResult });
        }
    }
}
