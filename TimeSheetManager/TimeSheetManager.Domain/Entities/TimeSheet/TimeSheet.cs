using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManager.Domain.Entities.DeveloperNS;

namespace TimeSheetManager.Domain.Entities.TimeSheetNS
{
    public class TimeSheet
    {
        public TimeSheet(Guid devId, DateTime entryTime, DateTime exitTime)
        {
            DevId = devId;
            EntryTime = entryTime;
            ExitTime = exitTime;
            WeekId = DateTime.Now.WeekNumberOfTheYear();
            TotalHours = (exitTime - entryTime).TotalHours;
        }

        public int Id { get; }
        public Guid DevId { get; }
        public DateTime EntryTime { get; }
        public DateTime ExitTime { get; }
        public int WeekId { get; }
        public double TotalHours { get; }
        public virtual Developer Developer { get; set; }

    }
}
