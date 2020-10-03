using System;

namespace TesteLuby.Domain.Contracts
{
    public interface IEntity
    {
        int Id { get; }
        Guid Guid { get; }
    }
}