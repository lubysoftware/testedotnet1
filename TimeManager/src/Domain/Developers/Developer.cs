using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Developers
{
    public class Developer : Entity
    {
        public string Name { get; private set; }

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
