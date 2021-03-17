using System;

namespace LTS.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public void SetId(Guid id) => Id = id;
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
