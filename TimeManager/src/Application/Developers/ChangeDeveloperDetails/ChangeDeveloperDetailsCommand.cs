using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.ChangeDeveloperDetails
{
    public class ChangeDeveloperDetailsCommand : IRequest<Response>
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
