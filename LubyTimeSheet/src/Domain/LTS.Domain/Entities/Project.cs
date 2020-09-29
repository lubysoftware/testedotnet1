using LTS.Domain.Base;
using System.Collections.Generic;

namespace LTS.Domain.Entities
{
    public class Project : EntityBase
    {
        public string Name { get; set; }
        public ICollection<TimeSheet> TimeSheets { get; set; }
        public ICollection<DeveloperProject> DeveloperProjects { get; set; }

        public Project() { }

        public Project(string name)
        {
            Name = name;

        }
    }
}