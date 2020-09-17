using System;

namespace TimeManager.Domain.Projects
{
    public class Project
    {

        public Guid Id { get; }
        public string Name { get; private set; }

        public Project(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
