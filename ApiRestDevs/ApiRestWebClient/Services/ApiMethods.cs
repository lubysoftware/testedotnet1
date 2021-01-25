using ApiRestWebClient.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiRestWebClient.Services
{
    public class ApiMethods
    {

        public TokenDto RetornaToken()
        {
            var retorno = ApiConsume.GetToken("/login", "teste", "teste").Result;

            var token = JsonConvert.DeserializeObject<TokenDto>(retorno);

            return token;
        }

        public IEnumerable<DesenvolvedorDto> RetornaDevs()
        {
            var rota = "http://localhost:5000/api/";
            var rest = "devs";
            var token = RetornaToken().Token;

            var resultado = ApiConsume.Get(rota, rest,token).Result;

            var resultadoDevs = JsonConvert.DeserializeObject<IEnumerable<DesenvolvedorDto>>(resultado);

            return resultadoDevs;

        }

        public IEnumerable<ProjetoDto> RetornaProjetos()
        {
            var rota = "http://localhost:5000/api/";
            var rest = "projetos";
            var token = RetornaToken().Token;

            var resultado = ApiConsume.Get(rota, rest, token).Result;

            var resultadoProjetos = JsonConvert.DeserializeObject<IEnumerable<ProjetoDto>>(resultado);

            return resultadoProjetos;
        }

        public IEnumerable<RankingDto> RetornaRanking()
        {
            var rota = "http://localhost:5000/api/";
            var rest = "lancarhora/ranking";
            var token = RetornaToken().Token;

            var resultado = ApiConsume.Get(rota, rest, token).Result;

            var resultadoProjetos = JsonConvert.DeserializeObject<IEnumerable<RankingDto>>(resultado);

            return resultadoProjetos;
        }

    }
}
