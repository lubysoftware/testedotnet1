using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Domain.Api.v1;
using LH001.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace LH001.Pages.LancamentoHora
{

    public class IndexModel : PageModel
    {
        [BindProperty]
        public Tb_LancamentoHoras modalBusca { get; set; }

        [BindProperty]
        public List<Tb_LancamentoHoras> modalResult { get; set; }

        [BindProperty]
        public int Id_Projeto { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> ListProjeto { get; set; }

        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGet()
        {
            var listaProj = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Listar();
            ListProjeto = listaProj.Select(c => new SelectListItem(){ Text = c.Nome, Value = c.Id.ToString() }).ToList();
            modalResult = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Listar();
            modalBusca = new Tb_LancamentoHoras();
            return Page();
        }

        public async Task<IActionResult> OnGetBuscar(int Id_Projeto, string NomeDesenv)
        {
            if (NomeDesenv == null && Id_Projeto == 0)
                modalResult = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Listar();
            else
            {
                modalBusca = new Tb_LancamentoHoras();
                modalResult = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Buscar(NomeDesenv, Id_Projeto.ToString());
            }
            return new JsonResult(new { ok = true, result = modalResult });
        }

        public async Task<IActionResult> OnGetDeletar(int id)
        {
            var ok = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Deletar(id.ToString());
            if (ok == "OK")
                return new JsonResult(new { ok = true });
            else
                return new JsonResult(new { ok = false, msg = ok });
        }

        public async Task<IActionResult> OnGetListaDesenvolvedor()
        {
            var d = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Listar();
            return new JsonResult(new { ok = true, result = d });
        }
    }
}
