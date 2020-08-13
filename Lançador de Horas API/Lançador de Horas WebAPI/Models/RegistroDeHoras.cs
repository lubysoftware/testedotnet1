using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Models
{
    public class RegistroDeHoras
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Data início")]
        public DateTime DataInicio { get; set; }

        [Required]
        [DisplayName("Data final")]
        public DateTime DataFim { get; set; }

        [Required]
        [DisplayName("Total de horas")]
        [DataType(DataType.Time, ErrorMessage = "Hora em formato inválido")]
        public TimeSpan TotalHoras { get; set; }

        [Required]
        [DisplayName("Desenvolvedor")]
        public int DesenvolvedorId { get; set; }

        [Required]
        [DisplayName("Projeto")]
        public int ProjetoId { get; set; }

        [ForeignKey("DesenvolvedorId")]
        public Desenvolvedor Desenvolvedor { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public RegistroDeHoras()
        {
        }
    }
}