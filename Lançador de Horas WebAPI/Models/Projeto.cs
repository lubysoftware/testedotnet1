using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome do projeto")]
        public string NomeDoProjeto { get; set; }

        [Required]
        [DisplayName("Custo")]
        public double Custo { get; set; }

        public Projeto()
        {
        }
    }
}