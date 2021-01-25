using ApiRestWebClient.Dto;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiRestWebClient.Services
{
    public class ApiMethods
    {

        public TokenDto RetornaToken()
        {
            var retorno = ApiConsume.GetToken("/login", "santi", "santi").Result;

            var token = JsonConvert.DeserializeObject<TokenDto>(retorno);

            return token;
        }

    }
}
