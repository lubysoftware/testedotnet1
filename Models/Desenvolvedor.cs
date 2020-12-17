using System;
using System.ComponentModel.DataAnnotations;

namespace testedotnet1.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter de 10 a 100 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter de 5 a 100 caracteres")]
        public string Nome {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha {get; set;}

        [MaxLength(250, ErrorMessage = "Esse campo ultrapassou a quantidade máxima de caracteres")]
        public string FotoUrl {get; set;}

        [MaxLength(9, ErrorMessage = "Esse campo ultrapassou a quantidade máxima de caracteres")]
        public string TipoDesenvolvedor {get; set;}

        [MaxLength(1024, ErrorMessage = "Esse campo ultrapassou a quantidade máxima de caracteres")]
        public string Descricao {get; set;}
        public DateTime DataCriacao {get; set;}
        public DateTime? DataAlteracao {get; set;}
        public DateTime? DataExclusao {get; set;}

    }
}