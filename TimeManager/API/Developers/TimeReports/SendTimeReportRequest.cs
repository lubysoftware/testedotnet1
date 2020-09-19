using System;

namespace API.Developers.TimeReports
{
    public class SendTimeReportRequest
    {
        public DateTime StartedAt { get; }
        public DateTime EndedAt { get; }
    }
}
