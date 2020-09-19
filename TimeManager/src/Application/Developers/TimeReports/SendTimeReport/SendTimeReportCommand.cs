using MediatR;
using System;

namespace TimeManager.Application.Developers.TimeReports.SendTimeReport
{
    public class SendTimeReportCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }
        public Guid DeveloperId { get; }

        public DateTime StartedAt { get; }
        public DateTime EndedAt { get; }

        public SendTimeReportCommand(Guid projectId, Guid developerId, DateTime startedAt, DateTime endedAt)
        {
            ProjectId = projectId;
            DeveloperId = developerId;
            StartedAt = startedAt;
            EndedAt = endedAt;
        }
    }
}
