using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoAPI.Domain.Models
{
    public class Desenvolvedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesenvolvedorID { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}