using System;

namespace TimeManager.Domain.Developers
{
    public class Developer
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        public Developer(string name)
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
