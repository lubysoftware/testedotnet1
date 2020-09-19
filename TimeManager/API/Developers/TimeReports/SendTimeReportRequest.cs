using System;

namespace API.Developers.TimeReports
{
    public class SendTimeReportRequest
    {
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }
}
