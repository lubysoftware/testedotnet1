using LubyHour.Domain.Interfaces;

namespace LubyHour.Domain.Commands.output
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
