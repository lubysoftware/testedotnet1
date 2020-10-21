using Dominio.Principal.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class RegistroHora : Entidade
    {
        public int DesenvolvedorId { get; set; }
        public virtual Desenvolvedor Desenvolvedor { get; set; }
        public DateTime? DataHoraEntrada { get; set; }                
        public DateTime? DataHoraSaida { get; set; }
        

        public RegistroHora()
        {
            SetNotificacao(new NotificacaoDominio());
        }

        public bool Validar(bool IsRemovendo)
        {
            if (!IsRemovendo)
            {
                if(DesenvolvedorId == 0)
                    NotificacaoDominio.AddErro("Um desenvolvedor deve ser selecionado.");
                if (!DataHoraEntrada.HasValue)
                    NotificacaoDominio.AddErro("Data/hora da entrada deve ser informada.");                
                if (!DataHoraSaida.HasValue)
                    NotificacaoDominio.AddErro("Data/hora da saída deve ser informada.");                
            }

            return NotificacaoDominio.ErroMensagens.Count() == 0;
        }
    }
}
