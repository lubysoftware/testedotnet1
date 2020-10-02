using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.Commands
{
    public class UpdateDeveloperCommand : ICommand
    {
        public string Guid { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
