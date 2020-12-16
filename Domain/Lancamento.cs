using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Lancamento")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int IdDesenvolvedor { get; set; }

        [ForeignKey("IdDesenvolvedor")]
        public Desenvolvedor Desenvolvedor { get; set; }
    }
}
