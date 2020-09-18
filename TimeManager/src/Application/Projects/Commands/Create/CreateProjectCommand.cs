using MediatR;
using System;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public CreateProjectCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
