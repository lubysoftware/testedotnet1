using IdentityModel.Client;
using LH001.Domain.Entidades;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LH001.Domain.Api.v1
{
    public class ChamadaProjeto
    {
        private readonly string _apiUrl;

        public ChamadaProjeto(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<List<Tb_Projeto>> Listar()
        {
            List<Tb_Projeto> Ds = new List<Tb_Projeto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiUrl + "/Api/V1.0/Projeto/Listar"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Projeto>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<List<Tb_Projeto>> Buscar(int Id, string Nome)
        {
            var query = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Nome"] = Nome== null? "": Nome
            };
            List<Tb_Projeto> Ds = new List<Tb_Projeto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Projeto/Buscar/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Projeto>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<List<Tb_Desenvolvedor_Projeto>> DesenvolvedoresPorProjetoId(int Id)
        {
            var query = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString()
            };
            List<Tb_Desenvolvedor_Projeto> DPs = new List<Tb_Desenvolvedor_Projeto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Projeto/DesenvolvedoresPorProjetoId/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    DPs = JsonConvert.DeserializeObject<List<Tb_Desenvolvedor_Projeto>>(apiResponse);
                }
            }
            return DPs;
        }

        public async Task<string> Incluir(string Nome, string Desenvolvedores)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>());
            var query = new Dictionary<string, string>
            {
                ["Nome"] = Nome,
                ["Desenvolvedores"] = Desenvolvedores
            };
            using (var httpClient = new HttpClient())
            {         
                using (var response = await httpClient.PostAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Projeto/Incluir/", query), content))
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK.ToString();
                    }
                }
            }
            return null;
        }

        public async Task<string> Alterar(int Id, string Nome, string Desenvolvedores)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>() });

            var query = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Nome"] = Nome,
                ["Desenvolvedores"] = Desenvolvedores == null ? "" : Desenvolvedores
            };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Projeto/Alterar/", query), content))
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK.ToString();
                    }
                }
            }
            return null;
        }

        public async Task<string> Deletar(string Id)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>("Id", Id) });
            var query = new Dictionary<string, string>
            {
                ["Id"] = Id
            };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Projeto/Excluir/", query)))
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK.ToString();
                    }
                }
            }
            return null;
        }
    }
}
