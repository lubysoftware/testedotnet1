using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Models
{
    public class Desenvolvedor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; private set; }

        public Desenvolvedor()
        {
        }
    }
}