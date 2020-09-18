using MediatR;

namespace TimeManager.Application.Developers.RegisterDeveloper
{
    public class RegisterDeveloperCommand : IRequest<Unit>
    {
        public string Name { get; }

        public RegisterDeveloperCommand(string name)
        {
            Name = name;
        }
    }
}
