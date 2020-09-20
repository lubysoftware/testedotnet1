using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.TimeReports.SendTimeReport
{
    public class SendTimeReportCommand : IRequest<Response>
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
