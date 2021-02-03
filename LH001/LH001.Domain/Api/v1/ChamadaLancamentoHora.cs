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
    public class ChamadaLancamentoHora
    {
        private readonly string _apiUrl;

        public ChamadaLancamentoHora(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<List<Tb_LancamentoHoras>> Listar()
        {
            List<Tb_LancamentoHoras> Ds = new List<Tb_LancamentoHoras>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiUrl + "/Api/V1.0/LancamentoHora/Listar"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_LancamentoHoras>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<List<Tb_LancamentoHoras>> Buscar(string NomeDesenv, string IdProj)
        {
            var query = new Dictionary<string, string>
            {
                ["NomeDesenv"] = NomeDesenv == null? "": NomeDesenv,
                ["IdProj"] = IdProj.ToString()
            };
            List<Tb_LancamentoHoras> Ds = new List<Tb_LancamentoHoras>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/LancamentoHora/Buscar/", query)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_LancamentoHoras>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<List<Tb_Desenvolvedor_Projeto>> EstatisticaPorDesenvolvedor()
        {
            List<Tb_Desenvolvedor_Projeto> Ds = new List<Tb_Desenvolvedor_Projeto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiUrl + "/Api/V1.0/LancamentoHora/EstatisticaPorDesenvolvedor/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Desenvolvedor_Projeto>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<List<Tb_Desenvolvedor_Projeto>> EstatisticaPorProjeto()
        {
            List<Tb_Desenvolvedor_Projeto> Ds = new List<Tb_Desenvolvedor_Projeto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiUrl + "/Api/V1.0/LancamentoHora/EstatisticaPorProjeto/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Ds = JsonConvert.DeserializeObject<List<Tb_Desenvolvedor_Projeto>>(apiResponse);
                }
            }
            return Ds;
        }

        public async Task<string> Incluir( int Desenv_Proj_Id, string DataInicio, string DataFim, string Hora)
        {
            var content = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>()});

            var query = new Dictionary<string, string>
            {
                ["Desenv_Proj_Id"] = Desenv_Proj_Id.ToString(),
                ["DataInicio"] = DataInicio,
                ["DataFim"] = DataFim,
                ["Hora"] = Hora
            };
            using (var httpClient = new HttpClient())
            {         
                using (var response = await httpClient.PostAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/LancamentoHora/Incluir/", query), content))
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
                    {new KeyValuePair<string, string>() });

            var query = new Dictionary<string, string>
            {
                ["Id"] = Id
            };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(QueryHelpers.AddQueryString(_apiUrl + "/Api/V1.0/LancamentoHora/Excluir/", query)))
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
