using MediatR;
using System;

namespace TimeManager.Application.Projects.CancelProject
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }

        public CancelProjectCommand(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
