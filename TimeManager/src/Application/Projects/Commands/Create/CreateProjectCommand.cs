using MediatR;
using System;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
