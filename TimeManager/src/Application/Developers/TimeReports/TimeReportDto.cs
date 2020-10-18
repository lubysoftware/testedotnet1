using System;

namespace TimeManager.Application.Developers.TimeReports
{
    public class TimeReportDto
    {
        public Guid Id { get; set; }
        public Guid DeveloperId { get; set;  }
        public Guid ProjectId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public double CalculatedSecondsWorked { get; set; }
        public int CalculatedWeekOfTheYear { get; set; }
    }
}
