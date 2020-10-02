namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Dados do usuário para login
    /// </summary>
    public class UserInfo
    {
        /// Email
        public string Email { get; set; }

        /// Senha
        public string Password { get; set; }
    }
}