using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApi.VO
{
    [NotMapped]
    public class HoraTrabalhadaVO
    {       
        public int DesenvolvedorId { get; set; }
        public string NomeDesenvolvedor{get;set;}
        public double TotalHoras { get; set; } 
    }
}