using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// BATALHA
namespace TesteApi.Models
{
    public class HoraTrabalhada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
    }
}