using System;
using MediatR;

namespace LubyClocker.CrossCuting.Shared.Common
{
    public class BasicCommand<T> : IRequest<T>
    {
        public Guid Id { get; internal set; }
        
        
        public BasicCommand<T> IncludeId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}