using MediatR;
using System;

namespace TimeManager.Application.Projects.RegisterMember
{
    public class RegisterProjectMemberCommand : IRequest<Unit>
    {
        public Guid DeveloperId { get; }
        public Guid ProjectId { get; }

        public RegisterProjectMemberCommand(Guid developerId, Guid projectId)
        {
            DeveloperId = developerId;
            ProjectId = projectId;
        }
    }
}
