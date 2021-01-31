using IdentityModel.Client;
using LH001.Domain.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LH001.Domain.Api.v1
{
    public class ChamadaDesenvolvedor
    {
        private readonly string _apiUrl;

        public ChamadaDesenvolvedor(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<List<Tb_Desenvolvedor>> Listar()
        {
            List<Tb_Desenvolvedor> Ds = new List<Tb_Desenvolvedor>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiUrl + "/Api/V1.0/Desenvolvedor/Listar"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Desenvolvedor>>(apiResponse);
                }
            }
            return Ds;
        }

        //public async Task<HttpResponseMessage> BuscaPorID(string token, int cdAplicacao)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(_apiUrl + "/Api/V1/Aplicacao/BuscaPorID");
        //    uriBuilder.Query = "cdAplicacao=" + cdAplicacao.ToString();
        //    var client = new HttpClient();
        //    client.SetBearerToken(token);

        //    return await client.GetAsync(uriBuilder.Uri);
        //}

        //public async Task<HttpResponseMessage> Buscar(string token, string CdProjeto, string NmAplicacao, bool? InAtivo, int page, int pageSize)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(_apiUrl + "/Api/V1/Aplicacao/Buscar");
        //    uriBuilder.Query += "CdProjeto=" + CdProjeto;
        //    uriBuilder.Query += "&NmAplicacao=" + NmAplicacao;
        //    uriBuilder.Query += "&InAtivo=" + InAtivo;
        //    uriBuilder.Query += "&page=" + page;
        //    uriBuilder.Query += "&pageSize=" + pageSize;

        //    var client = new HttpClient();
        //    client.SetBearerToken(token);

        //    return await client.GetAsync(uriBuilder.Uri);
        //}
        //public async Task<HttpResponseMessage> Incluir(string token, Aplicacao me)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(_apiUrl + "/Api/V1/Aplicacao/Incluir");

        //    string jsonInput = JsonConvert.SerializeObject(me);
        //    var content = new StringContent(jsonInput, Encoding.UTF8, "application/json");

        //    var client = new HttpClient();
        //    client.SetBearerToken(token);

        //    return await client.PostAsync(uriBuilder.Uri, content);
        //}

        //public async Task<HttpResponseMessage> Alterar(string token, Aplicacao me)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(_apiUrl + "/Api/V1/Aplicacao/Alterar");

        //    string jsonInput = JsonConvert.SerializeObject(me);
        //    var content = new StringContent(jsonInput, Encoding.UTF8, "application/json");

        //    var client = new HttpClient();
        //    client.SetBearerToken(token);

        //    return await client.PutAsync(uriBuilder.Uri, content);
        //}

        //public async Task<HttpResponseMessage> Excluir(string token, int cdAplicacao)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(_apiUrl + "/Api/V1/Aplicacao/Excluir");
        //    uriBuilder.Query = "cdAplicacao=" + cdAplicacao.ToString();

        //    var client = new HttpClient();
        //    client.SetBearerToken(token);

        //    return await client.DeleteAsync(uriBuilder.Uri);
        //}
    }
}
