using MediatR;
using System;

namespace TimeManager.Application.Developers.RemoveDeveloper
{
    public class RemoveDeveloperCommand : IRequest<Unit>
    {
        public Guid DeveloperId { get; }

        public RemoveDeveloperCommand(Guid developerId)
        {
            DeveloperId = developerId;
        }
    }
}
