using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Extensoes;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Infrastructure.Utility;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Models;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Entidades
{
    public class ProjetoServico : IProjetoServico
    {
        public HttpClient HttpClient { get; }
        public AppSettings AppSettings { get; }

        public ProjetoServico(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
            AppSettings.CheckArgumentIsNull(nameof(AppSettings));

            HttpClient = httpClient;
            HttpClient.CheckArgumentIsNull(nameof(HttpClient));

            if (httpClient.BaseAddress == null)
                HttpClient.BaseAddress = new Uri(AppSettings.ControleHorasApiAddress);
        }

        public async Task InserirAsync(ProjetoModel projetoModel)
        {
            await HttpClient.PostAsJsonAsync(HttpClient.BaseAddress + "projetos", projetoModel);
        }

        public async Task EditarAsync(ProjetoModel projetoModel)
        {
            await HttpClient.PutAsJsonAsync(HttpClient.BaseAddress + "projetos", projetoModel);
        }

        public async Task<IList<ProjetoModel>> CarregarProjetosAsync()
        {
            var reqMessage = new HttpRequestMessage(HttpMethod.Get, HttpClient.BaseAddress + "projetos");
            var res = await HttpClient.SendAsync(reqMessage);

            var resBody = await res.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<List<ProjetoModel>>(resBody);

            retorno.ToList();

            return await Task.FromResult(retorno);
        }
               

        public async Task<ProjetoModel> GetById(int id)
        {
            var reqMessage = new HttpRequestMessage(HttpMethod.Get, HttpClient.BaseAddress + "projetos/" + id);
            var res = await HttpClient.SendAsync(reqMessage);

            var resBody = await res.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<ProjetoModel>(resBody);

            return await Task.FromResult(retorno);
        }        
    }
}
