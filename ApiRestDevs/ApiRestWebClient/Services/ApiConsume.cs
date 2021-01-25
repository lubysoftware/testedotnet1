using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace ApiRestWebClient.Services
{
    public class ApiConsume
    {
        private static readonly RestClient restClient = new RestClient();
        private static readonly string Url = "http://localhost:5000/api/";

        public static async Task<string> GetToken(string rest, string username, string password)
        {
            restClient.BaseUrl = new Uri(Url);
            var request = new RestRequest(rest, Method.POST);
            request.AddJsonBody(new { username = username, password = password });

            var response = await restClient.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(string url, string rest, string token)
        {
            restClient.BaseUrl = new Uri(url);
            var request = new RestRequest(rest, Method.GET);

            if (!string.IsNullOrWhiteSpace(token))
                restClient.Authenticator = new JwtAuthenticator(token);


            var response = await restClient.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<string> Post(string url, string rest, string token = "",
            object jsonBody = null, Dictionary<string, string> header = null)
        {
            restClient.BaseUrl = new Uri(url);
            var request = new RestRequest(rest, Method.POST);

            if (header != null)
                foreach (var item in header)
                    request.AddQueryParameter(item.Key, item.Value);

            if (!string.IsNullOrWhiteSpace(token))
                restClient.Authenticator = new JwtAuthenticator(token);

            if (jsonBody != null)
                request.AddJsonBody(jsonBody);

            var response = await restClient.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await Task.FromException<ArgumentException>(new ArgumentException(response.Content));
            }

            return response.Content;
        }

    }
}
