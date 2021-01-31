using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LH001.Domain.Entidades
{
    public class Tb_LancamentoHoras
    {
        [Key]
        public int Id { get; set; }
        public int Tb_Desenvolvedor_ProjetoId { get; set; }
        public Tb_Desenvolvedor_Projeto Tb_Desenvolvedor_Projeto { get; set; }

        public DateTime DataFim { get; set; }
        public DateTime DataInicio { get; set; }
        public string Horas { get; set; }

    }
}
