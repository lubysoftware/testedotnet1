using MediatR;
using System;

namespace TimeManager.Application.Developers.TimeReports.GetTimeReports
{
    public class GetTimeReportsQuery : IRequest<TimeReportsViewModel>
    {
        public Guid DeveloperId { get; }

        public GetTimeReportsQuery(Guid developerId)
        {
            DeveloperId = developerId;
        }
    }
}
