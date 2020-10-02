using System;
using TesteLuby.Domain.Contracts;

namespace TesteLuby.Domain.Models.Entities
{
    public abstract class EntityModels : IEntity
    {
        public int Id { get; private set; }
        public Guid Guid { get; set; }
    }
}
