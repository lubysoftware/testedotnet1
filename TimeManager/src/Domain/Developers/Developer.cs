using System.Collections.Generic;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Developers
{
    public class Developer : Entity
    {
        public string Name { get; private set; }

        public virtual IEnumerable<TimeReport> TimeReports { get; set; }
        public Developer(string name)
        {
            Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
