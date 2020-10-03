using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.CommandsParameters
{
    public class UpdateProjectCommand : ICommand
    {
        public string Guid { get; set; }
        public string ProjectName { get; set; }
    }
}
