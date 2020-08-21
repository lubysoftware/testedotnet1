using LubyHour.Domain.Interfaces;
using System;
namespace LubyHour.Domain.Entities
{
    // A api vai gerar o Id de todas as Entidades através dessa classe
    // Toda entidade terá um Id salvo na base
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}