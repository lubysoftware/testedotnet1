using MediatR;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.RegisterDeveloper
{
    public class RegisterDeveloperCommand : IRequest<Response>
    {
        public string Name { get; }

        public RegisterDeveloperCommand(string name)
        {
            Name = name;
        }
    }
}
