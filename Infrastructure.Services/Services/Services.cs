using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Services<T> : IServices<T> where T : class
    {
        public static string Url = "https://localhost:44324/api";
        public string Endpoint;       

        public string SetEndpoint(string endpoint)
        {
            this.Endpoint = endpoint;
            return endpoint;
        }

        public async Task<List<T>> Get()
        {            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(@$"{Url}/{Endpoint}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<T>>(apiResponse);
                    }

                    return null;
                }
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(@$"{Url}/{Endpoint}/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                    }

                    return null;
                }
            }
        }

        public async Task<T> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(@$"{Url}/{Endpoint}/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(apiResponse);                        
                    }

                    return null;
                }
            }
        }

        public async Task<T> Post(T entity)
        {
            using (var httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(@$"{Url}/{Endpoint}", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                    }

                    return null;
                }
            }
        }

        public async Task<T> Put(int id, T entity)
        {            
            using (var httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(@$"{Url}/{Endpoint}/{id}", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();                    
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                    return null;
                }
            }
        }
    }
}
