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
using Microsoft.AspNetCore.Http;

namespace LH001.Pages.LancamentoHora
{
    public class AdicionarModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public Tb_LancamentoHoras modal { get; set; }

        [BindProperty]
        public string ModoTela { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> ListProjeto { get; set; }
        public AdicionarModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> OnGet(int? Id)
        {
            modal = new Tb_LancamentoHoras();
            var listaProj = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).Listar();
            ListProjeto = listaProj.Where(x => x.InAtivo == true).ToList().Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            var Result = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Listar();

            if (Id != null)
            {
                ModoTela = "V";
                modal = Result.FirstOrDefault(x => x.Id == (int)Id);
            }
            else
                ModoTela = "I";

            if (Result.Count() != 0)
                modal.Id = Result.LastOrDefault().Id + 1;
            else
                modal.Id = 1;
            return Page();
        }
        public async Task<IActionResult> OnGetAdicionar(int Desenv_Id, int Proj_Id, string DataInicio, string DataFim, string Hora)
        {
            var DataInvalida = new DateTime();
            if (Desenv_Id == 0 || Proj_Id == 0 || String.IsNullOrEmpty(Hora) || DateTime.Parse(DataInicio) == DataInvalida || DateTime.Parse(DataFim) == DataInvalida)
                return new JsonResult(new { ok = false, msg = "Preencha todos os campos. " });

            if ((!Hora.Contains(":")) || (!DataInicio.Contains("/")) || (!DataFim.Contains("/")))
                return new JsonResult(new { ok = false, msg = "Digite os campos de forma correta" });

            if (DateTime.Parse(DataFim) >= DateTime.Now.AddDays(+1).Date)
                return new JsonResult(new { ok = false, msg = "Data Fim não pode ser maior que o dia atual." });

            var D = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).DesenvolvedoresPorProjetoId(Proj_Id);
            var Desenv_Proj_Id = D.FirstOrDefault(x => x.Tb_DesenvolvedorId == Desenv_Id).Id;

            var r = await new ChamadaLancamentoHora(_configuration["URLs:LH.Service"]).Incluir(Desenv_Proj_Id, DataInicio, DataFim, Hora);

            if (r == "OK")
                return new JsonResult(new { ok = true });
            else
            {
                modal = new Tb_LancamentoHoras();
                return new JsonResult(new { ok = false, msg = "Erro não identicado ocorrido. " + r });
            }
        }

        public async Task<IActionResult> OnGetListaDesenvolvedor(int IdProjeto)
        {
            var d = await new ChamadaProjeto(_configuration["URLs:LH.Service"]).DesenvolvedoresPorProjetoId(IdProjeto);
            return new JsonResult(new { ok = true, result = d });
        }
    }
}
