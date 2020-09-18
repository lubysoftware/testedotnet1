using MediatR;
using System;

namespace TimeManager.Application.Projects.Commands.Update
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }
        public string Name { get; }

        public UpdateProjectCommand(Guid id, string name)
        {
            ProjectId = id;
            Name = name;
        }
    }
}
