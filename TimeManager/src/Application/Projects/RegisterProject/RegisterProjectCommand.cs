using MediatR;

namespace TimeManager.Application.Projects.RegisterProject
{
    public class RegisterProjectCommand : IRequest<Unit>
    {
        public string Name { get; }

        public RegisterProjectCommand(string name)
        {
            Name = name;
        }
    }
}
