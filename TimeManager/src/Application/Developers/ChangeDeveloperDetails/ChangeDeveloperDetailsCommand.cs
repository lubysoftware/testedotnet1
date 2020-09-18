using MediatR;
using System;

namespace TimeManager.Application.Developers.ChangeDeveloperDetails
{
    public class ChangeDeveloperDetailsCommand : IRequest<Unit>
    {
        public Guid DeveloperId { get; }

        public string Name { get; }

        public ChangeDeveloperDetailsCommand(Guid developerId, string name)
        {
            DeveloperId = developerId;
            Name = name;
        }
    }
}
