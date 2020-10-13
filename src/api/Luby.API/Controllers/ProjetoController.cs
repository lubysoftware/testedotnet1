namespace Luby.API.Controllers
{
    using Luby.Core.Notificacoes;
    public class ProjetoController : BaseController
    {
        public ProjetoController(INotificador notificador) : base(notificador) { }
    }
}