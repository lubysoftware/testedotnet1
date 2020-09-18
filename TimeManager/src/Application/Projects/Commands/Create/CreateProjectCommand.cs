using MediatR;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<ProjectDto>
    {
        public CreateProjectCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
