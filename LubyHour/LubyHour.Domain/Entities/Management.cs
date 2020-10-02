using System;

namespace LubyHour.Domain.Entities
{
    public class Management : Entity
    {
        public Management() { }
        public Management(string developer, DateTime startTime, DateTime endTime)
        {
            Developer = developer;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Developer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
