using System;

namespace LubyHour.Domain.Entities
{
    public class Management : Entity
    {
        public string Developer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
