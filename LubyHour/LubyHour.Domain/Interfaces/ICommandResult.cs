namespace LubyHour.Domain.Interfaces
{
    public interface ICommandResult
    {
        string Message { get; }
        bool Success { get; }
        object Data { get; }
    }
}