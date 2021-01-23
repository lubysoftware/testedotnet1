using ApiRestWebClient.Dto;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiRestWebClient.Services
{
    public class ResponseApi
    {

        public TokenDto RetornaToken()
        {
            var retorno = ApiConsume.GetToken("/login").Result;

            var token = JsonConvert.DeserializeObject<TokenDto>(retorno);

            return token;
        }

    }
}
