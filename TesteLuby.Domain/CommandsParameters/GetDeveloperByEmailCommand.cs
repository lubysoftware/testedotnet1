using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.Commands
{
    public class GetDeveloperByEmailCommand : ICommand
    {
        public string Email { get; set; }
    }
}
