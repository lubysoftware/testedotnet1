using System.Threading.Tasks;
using TimeSheetManager.App.Commands.Contracts;

namespace TimeSheetManager.App.Handlers.Contracts
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> Handle(TCommand command);
    }
}