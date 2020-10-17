using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class RegistroHora : Entidade
    {
        public int DesenvolvedorId { get; set; }
        public virtual Desenvolvedor Desenvolvedor { get; set; }

        public DateTime DataHoraEntrada { get; set; }        
        public DateTime DataHoraSaida { get; set; }
    }
}
