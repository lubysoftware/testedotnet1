using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LH001.Domain.Entidades
{
    public class Tb_Desenvolvedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        //public ICollection<Tb_Desenvolvedor> Tb_Desenvolvedores { get; set; }
    }
}
