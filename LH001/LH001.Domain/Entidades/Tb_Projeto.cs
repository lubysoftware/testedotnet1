using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LH001.Domain.Entidades
{
    public partial class Tb_Projeto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public bool InAtivo { get; set; }
    }
}
