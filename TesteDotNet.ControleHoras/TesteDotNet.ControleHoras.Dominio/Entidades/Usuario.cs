using Dominio.Principal.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Dominio.Principal.Entidades
{
    public class Usuario : Entidade
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public Usuario()
        {
            SetNotificacao(new NotificacaoDominio());
        }
    }
}
