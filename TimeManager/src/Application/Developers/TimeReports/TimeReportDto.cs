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
        public TimeSpan CalculatedTimeWorked { get; set; }
        public int CalculatedWeekNumber { get; set;  }
    }
}
