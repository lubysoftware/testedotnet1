namespace Luby.Core.Interfaces.Services
{
    using System.Threading.Tasks;
    using Luby.Core.Model;
    public interface IProjetoService : IBaseService<Projeto> 
    {   
        Task Lancar(ProjetoDesenvolvedores projetoDesenvolvedores);
    }
}
