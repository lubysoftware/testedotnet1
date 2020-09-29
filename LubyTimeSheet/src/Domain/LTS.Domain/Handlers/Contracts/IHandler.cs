using LTS.Domain.Commands.Contracts;
using System.Threading.Tasks;

namespace LTS.Domain.Handlers.Contracts
{
    public interface IHandler<TCommand>
        where TCommand : ICommand
    {
        Task<ICommandResult> Handle(TCommand command);
    }
}
