using System;
using System.ComponentModel.DataAnnotations;

namespace testedotnet1.Models
{
    public class Projeto
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter de 10 a 100 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter de 5 a 100 caracteres")]
        public string Titulo {get; set;}

        [Required]
        [MaxLength(1024, ErrorMessage = "Esse campo ultrapassou a quantidade máxima de caracteres")]
        public string Descricao {get; set;}

        [Required]
        public DateTime DataInicio {get; set;}
        public DateTime? DataFinal {get; set;}
        public int? DesenvolvedorId {get; set;}
        public DateTime DataCriacao {get; set;}
        public DateTime? DataAlteracao {get; set;}
        public DateTime? DataExclusao {get; set;}

    }
}