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
    public class DesenvolvedorServico : IDesenvolvedorServico
    {        
        public HttpClient HttpClient { get; }
        public AppSettings AppSettings { get; }

        public DesenvolvedorServico(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
            AppSettings.CheckArgumentIsNull(nameof(AppSettings));

            HttpClient = httpClient;
            HttpClient.CheckArgumentIsNull(nameof(HttpClient));

            if (httpClient.BaseAddress == null)
                HttpClient.BaseAddress = new Uri(AppSettings.ControleHorasApiAddress);
        }

        public async Task<IList<DesenvolvedorModel>> CarregarDesenvolvedoresAsync()
        {
            var reqMessage = new HttpRequestMessage(HttpMethod.Get, HttpClient.BaseAddress + "desenvolvedores");
            var res = await HttpClient.SendAsync(reqMessage);

            var resBody = await res.Content.ReadAsStringAsync();
            var desenvolvedoresRetorno = JsonConvert.DeserializeObject<List<DesenvolvedorModel>>(resBody);

            desenvolvedoresRetorno.ToList();

            return await Task.FromResult(desenvolvedoresRetorno);
        }
    }    
}
