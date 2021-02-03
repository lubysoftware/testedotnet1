using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LH001.Domain.Entidades
{
    public partial class Tb_Desenvolvedor_Projeto
    {
        [NotMapped]
        public double HorasTotais { get; set; }

        [NotMapped]
        public int NumeroDiasTrabalhados { get; set; }


        [NotMapped]
        public int Media { get; set; }

        [NotMapped]
        public string ProjetosEstatisticas { get; set; }

    }
}
