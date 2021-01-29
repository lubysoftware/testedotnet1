using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ARMA
namespace TesteApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public Desenvolvedor Desenvolvedor { get; set; }

        public int DesenvolvedorId { get; set; }
    }
}