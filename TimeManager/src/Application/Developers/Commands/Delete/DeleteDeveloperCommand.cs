using MediatR;
using System;

namespace TimeManager.Application.Developers.Commands.Delete
{
    public class DeleteDeveloperCommand : IRequest<Unit>
    {
        public Guid DeveloperId { get; }

        public DeleteDeveloperCommand(Guid developerId)
        {
            DeveloperId = developerId;
        }
    }
}
