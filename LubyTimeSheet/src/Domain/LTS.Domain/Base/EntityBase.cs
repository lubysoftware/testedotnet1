using System;

namespace LTS.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
