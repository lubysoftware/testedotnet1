using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Desenvolvedor")]
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
                
        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
