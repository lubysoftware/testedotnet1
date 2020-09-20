using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Projects.CancelProject
{
    public class CancelProjectCommand : IRequest<Response>
    {
        public Guid ProjectId { get; }

        public CancelProjectCommand(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
