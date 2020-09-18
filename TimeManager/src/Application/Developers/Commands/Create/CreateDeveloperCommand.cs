using MediatR;

namespace TimeManager.Application.Developers.Commands.Create
{
    public class CreateDeveloperCommand : IRequest<Unit>
    {
        public string Name { get; }

        public CreateDeveloperCommand(string name)
        {
            Name = name;
        }
    }
}
