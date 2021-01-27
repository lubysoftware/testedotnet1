using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteApi.Models;

namespace TesteApi.Controllers
{
    public class DesenvolvedoresController : ApiController
    {
        private static List<Desenvolvedor> desenvolvedores = new List<Desenvolvedor>();

        public List<Desenvolvedor> Get()
        {
            return desenvolvedores;
        }

        public void Post(string nome)
        {
            if(!string.IsNullOrEmpty(nome))
                desenvolvedores.Add(new Desenvolvedor(nome));
        }

        public void Delete(string nome)
        {
            desenvolvedores.RemoveAt(desenvolvedores.IndexOf(desenvolvedores.First(e => e.Nome.Equals(nome))));
        }

    }
}