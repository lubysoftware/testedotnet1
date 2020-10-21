using Dominio.Principal.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class Projeto : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public Projeto()
        {
            SetNotificacao(new NotificacaoDominio());
        }

        public bool Validar(bool IsRemovendo)
        {
            if (!IsRemovendo)
            {
                if (String.IsNullOrWhiteSpace(Nome))
                    NotificacaoDominio.AddErro("Nome do projeto deve ser informado.");
                else if (Nome.Length <= 2)
                    NotificacaoDominio.AddErro("Nome do projeto deve ter no mínimo 2 caracteres.");
            }

            return NotificacaoDominio.ErroMensagens.Count() == 0;
        }
    }
}
