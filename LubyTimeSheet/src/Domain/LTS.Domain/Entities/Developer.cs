using LTS.Domain.Base;
using System.Collections.Generic;

namespace LTS.Domain.Entities
{
    public class Developer : EntityBase
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public ICollection<TimeSheet> TimeSheets { get; protected set; }
        public ICollection<DeveloperProject> DeveloperProjects { get; protected set; }
        public string LinkedinURL { get; protected set; }

        protected Developer() { }
        public Developer(string name, int age, string linkedinURL)
        {
            Name = name;
            Age = age;
            LinkedinURL = linkedinURL;
        }
    }
}
