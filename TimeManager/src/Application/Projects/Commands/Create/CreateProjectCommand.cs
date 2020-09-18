using MediatR;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Unit>
    {
        public string Name { get; }

        public CreateProjectCommand(string name)
        {
            Name = name;
        }
    }
}
