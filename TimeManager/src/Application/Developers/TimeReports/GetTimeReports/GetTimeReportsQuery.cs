using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.TimeReports.GetTimeReports
{
    public class GetTimeReportsQuery : IRequest<Response>
    {
        public Guid DeveloperId { get; }

        public GetTimeReportsQuery(Guid developerId)
        {
            DeveloperId = developerId;
        }
    }
}
