using MediatR;
using System;

namespace TimeManager.Application.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }

        public DeleteProjectCommand(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
