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

        public DateTime? DataEntrada { get; set; }        
        public TimeSpan? HoraEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public TimeSpan? HoraSaida { get; set; }

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
                if (!DataEntrada.HasValue)
                    NotificacaoDominio.AddErro("Data da entrada deve ser informada.");
                if(!HoraEntrada.HasValue)
                    NotificacaoDominio.AddErro("Hora da entrada deve ser informada.");
                if (!DataSaida.HasValue)
                    NotificacaoDominio.AddErro("Data da saída deve ser informada.");
                if (!HoraSaida.HasValue)
                    NotificacaoDominio.AddErro("Hora da saída deve ser informada.");                                
            }

            return NotificacaoDominio.ErroMensagens.Count() == 0;
        }
    }
}
