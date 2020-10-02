

namespace TesteLuby.Domain.Contracts
{
    public interface ICommandResult
    {
        int Status { get; }
        string Message { get; }
        bool Success { get; }
        object Data { get; }
    }
}
