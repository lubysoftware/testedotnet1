using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LH001.Domain.Entidades
{
    public partial class Tb_Projeto
    {
        [NotMapped]
        public string TipoTela { get; set; }

        // I - Incluir ou E - Editar

        [NotMapped]
        public string ListaDesenvolvedor { get; set; }
    }
}
