using System;
using System.ComponentModel.DataAnnotations;

namespace testedotnet1.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(1024, ErrorMessage = "Esse campo ultrapassou a quantidade máxima de caracteres")]
        public string Descricao {get; set;}

        [Required]
        public int QuantidadeEstrelas {get; set;}

        [Required]
        public int ProjetoId {get; set;}
        public DateTime DataCriacao {get; set;}

    }
}