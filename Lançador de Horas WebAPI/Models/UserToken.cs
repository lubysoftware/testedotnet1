using System;

namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Dados do token para acesso a api
    /// </summary>
    public class UserToken
    {
        /// Chave do Token
        public string Token { get; set; }

        /// Tempo de expiração do Token
        public DateTime Expiration { get; set; }
    }
}