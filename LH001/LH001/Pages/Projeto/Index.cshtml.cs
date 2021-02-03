using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Domain.Api.v1;
using LH001.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LH001.Pages.Projeto
{

    public class IndexModel : PageModel
    {
        [BindProperty]
        public Tb_Projeto modalBusca { get; set; }

        [BindProperty]
        public List<Tb_Projeto> modalResult { get; set; }

        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGet()
        {
            modalResult = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Listar();
            modalResult = modalResult.Where(x => x.InAtivo == true).ToList();
            modalBusca = new Tb_Projeto();
            return Page();
        }

        public async Task<IActionResult> OnGetBuscar(int id, string nome)
        {
            if (nome == null && id == 0)
            {
                modalResult = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Listar();
                modalResult = modalResult.Where(x => x.InAtivo == true).ToList();
            }
            else
            {
                modalBusca = new Tb_Projeto();
                modalBusca.Id = id;
                modalBusca.Nome = nome;
                modalResult = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Buscar(id, nome);
            }
            return new JsonResult(new { ok = true, result = modalResult });
        }

        public async Task<IActionResult> OnGetDeletar(int id)
        {
            var ok = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Deletar(id.ToString());
            if (ok == "OK")
                return new JsonResult(new { ok = true });
            else
                return new JsonResult(new { ok = false, msg = ok });
        }
    }
}
