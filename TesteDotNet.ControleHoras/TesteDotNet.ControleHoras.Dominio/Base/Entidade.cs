using Dominio.Core.Interfaces.Notificacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class Entidade
    {
        [Key]
        public int Id { get; set; }

        private INotificacaoDominio _notificacaoDominio;
        protected INotificacaoDominio NotificacaoDominio
        {
            get
            {
                if (_notificacaoDominio == null)
                    throw new Exception("Atenção! Objeto 'NotificacaoDominio' não foi instanciado.");
                                       
                return  _notificacaoDominio;
            }
        }

        public void SetNotificacao(INotificacaoDominio notificacaoDominio)
        {
            _notificacaoDominio = notificacaoDominio;
        }

        public bool EhValido()
        {
            return _notificacaoDominio.Validado();
        }

        public IEnumerable<string> Erros => _notificacaoDominio.ErroMensagens;
        public IEnumerable<string> Avisos => _notificacaoDominio.AvisoMensagens;
    }
}
