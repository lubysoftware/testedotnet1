
using System.Threading.Tasks;

namespace LubyHour.Domain.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
