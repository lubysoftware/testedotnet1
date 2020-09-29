using LTS.Domain.Base;
using System;

namespace LTS.Domain.Entities
{
    public class TimeSheet : EntityBase
    {
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid DevelopeId { get; protected set; }
        public Guid ProjectId { get; protected set; }
        public double TotalHours { get; set; }
        public Developer Developer { get; protected set; }
        public Project Project { get; protected set; }

        protected TimeSheet() { }
        public TimeSheet(DateTime dateBegin, DateTime dateEnd, Guid developeId, Guid projectId, double totalHours)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            DevelopeId = developeId;
            ProjectId = projectId;
            TotalHours = totalHours;
        }

        public TimeSheet(DateTime dateBegin, DateTime dateEnd, double totalHours)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            TotalHours = totalHours;
        }
    }
}