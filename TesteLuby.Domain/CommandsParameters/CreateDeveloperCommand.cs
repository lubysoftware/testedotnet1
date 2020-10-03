using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.Commands
{
    public class CreateDeveloperCommand : ICommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
