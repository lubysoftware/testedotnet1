using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lançador_de_Horas_WebAPI.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        public Desenvolvedor()
        {
        }
    }
}