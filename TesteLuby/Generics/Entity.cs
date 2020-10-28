using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLuby.Interfaces;

namespace TesteLuby.Generics
{
    public abstract class BaseEntity
    {

    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
