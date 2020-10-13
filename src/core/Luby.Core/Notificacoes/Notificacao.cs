namespace Luby.Core.Notificacoes
{
    /// <summary>
    /// Classe que representa todos os erros de validação de campo, tanto no FluentValidation quanto no ModelState
    /// Os Services que irão utilizar essa classe
    /// </summary>
    public class Notificacao
    {
        public Notificacao(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
