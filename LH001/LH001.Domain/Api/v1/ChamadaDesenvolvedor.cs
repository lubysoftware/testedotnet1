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

        public async Task<List<Tb_Desenvolvedor>> Buscar(int Id, string Nome)
        {
            var query = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Nome"] = Nome== null? "": Nome
            };
            List<Tb_Desenvolvedor> Ds = new List<Tb_Desenvolvedor>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Desenvolvedor/Buscar/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Desenvolvedor>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<string> Incluir(string Nome)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>("Nome", Nome) });
            var query = new Dictionary<string, string>
            {
                ["Nome"] = Nome
            };
            using (var httpClient = new HttpClient())
            {         
                using (var response = await httpClient.PostAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Desenvolvedor/Incluir/", query), content))
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK.ToString();
                    }
                }
            }
            return null;
        }

        public async Task<string> Alterar(int Id, string Nome)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>("Nome", Nome), new KeyValuePair<string, string>("Id", Id.ToString()) });
            var query = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Nome"] = Nome
            };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Desenvolvedor/Alterar/", query), content))
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
                using (var response = await httpClient.DeleteAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/Desenvolvedor/Excluir/", query)))
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
