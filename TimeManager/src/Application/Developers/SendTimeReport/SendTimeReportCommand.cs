using MediatR;
using System;

namespace TimeManager.Application.Developers.SendTimeReport
{
    public class SendTimeReportCommand : IRequest<Unit>
    {
        public Guid ProjectMemberId { get; }
        public DateTime StartedAt { get; }
        public DateTime EndedAt { get; }

        public SendTimeReportCommand(Guid projectMemberId, DateTime startedAt, DateTime endedAt)
        {
            ProjectMemberId = projectMemberId;
            StartedAt = startedAt;
            EndedAt = endedAt;
        }
    }
}
