using MediatR;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Projects.RegisterProject
{
    public class RegisterProjectCommand : IRequest<Response>
    {
        public string Name { get; }

        public RegisterProjectCommand(string name)
        {
            Name = name;
        }
    }
}
