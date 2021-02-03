using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LH001.Domain.Entidades
{
    public partial class Tb_Desenvolvedor_Projeto
    {
        [Key]
        public int Id { get; set; }
        public int Tb_DesenvolvedorId { get; set; }
        public Tb_Desenvolvedor Tb_Desenvolvedor { get; set; }
        public int Tb_ProjetoId { get; set; }
        public Tb_Projeto Tb_Projeto { get; set; }

        public bool InAtivo { get; set; }
    }
}
