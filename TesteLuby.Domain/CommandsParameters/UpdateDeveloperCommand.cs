using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.Commands
{
    public class UpdateDeveloperCommand : ICommand
    {
        public string Guid { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }
        public string Password { get; set; }
    }
}
