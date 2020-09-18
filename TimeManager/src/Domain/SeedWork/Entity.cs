using System;

namespace TimeManager.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
