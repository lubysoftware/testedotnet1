using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.RemoveDeveloper
{
    public class RemoveDeveloperCommand : IRequest<Response>
    {
        public Guid DeveloperId { get; }

        public RemoveDeveloperCommand(Guid developerId)
        {
            DeveloperId = developerId;
        }
    }
}
