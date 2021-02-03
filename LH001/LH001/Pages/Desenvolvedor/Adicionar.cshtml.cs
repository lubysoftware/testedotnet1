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
        public async Task<IActionResult> OnGet(int? id)
        {
            modal = new Tb_Desenvolvedor();
            if (id == null)
            {
                var Result = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Listar();

                if (Result.Count() != 0)
                    modal.Id = Result.LastOrDefault().Id + 1;
                else
                    modal.Id = 1;
                modal.TipoTela = "I";
            }
            else
            {
                var r = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Buscar((int)id, "");
                var Result = r.FirstOrDefault();
                modal.Id = Result.Id;
                modal.Nome = Result.Nome;
                modal.TipoTela = "E";
                HttpContext.Session.SetInt32("D_Edit", (int)id);


            }
            
            return Page();
        }

        [BindProperty]
        public Tb_Desenvolvedor Tb_Desenvolvedor { get; set; }

        public async Task<IActionResult> OnGetAdicionar(string nome, string TipoTela)
        {
            if (String.IsNullOrEmpty(nome))
                return new JsonResult(new { ok = false, msg = "Digite um nome." });

            int? id = HttpContext.Session.GetInt32("D_Edit");

            var Result = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Listar();
            if(Result.Any(x=>x.Nome.ToLower() == nome.ToLower() && (TipoTela == "E" ? x.Id != (int)id: true)))
                return new JsonResult(new { ok = false, msg = "Esse nome já está cadastrado!" });

            var r = string.Empty;
            if (TipoTela == "E")
            {

                r = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Alterar((int)id, nome);
            }
            else
            {
                r = await new ChamadaDesenvolvedor(_configuration["URLs:LH.Service"]).Incluir(nome);
            }


            if (r == "OK")
                return new JsonResult(new { ok = true});
            else
            {
                modal = new Tb_Desenvolvedor();
                modal.Nome = nome;
                return new JsonResult(new { ok = false, msg = "Erro não identicado ocorrido." });
            }
        }
    }
}
