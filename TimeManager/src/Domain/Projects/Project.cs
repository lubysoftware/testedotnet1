using System.Collections.Generic;
using TimeManager.Domain.Projects.ProjectMembers;
using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Projects
{
    public class Project : Entity
    {
        public string Name { get; private set; }

        public virtual IEnumerable<ProjectMember> Members { get; set; }

        public Project(string name)
        {
            Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
