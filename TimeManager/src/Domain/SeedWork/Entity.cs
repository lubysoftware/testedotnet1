using System;

namespace TimeManager.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; }

        public bool IsActive { get; private set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
        }

        public void SetInactive()
        {
            this.IsActive = false;
        }
    }
}
