using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_API.Models
{
    public class Projeto
    {
        public int ID { get; set; }
        public string NomeDoProjeto { get; set; }
        public double Custo { get; set; }

        public Projeto()
        {
        }
    }
}