using MediatR;
using System;

namespace TimeManager.Application.Developers.Commands.Update
{
    public class UpdateDeveloperCommand : IRequest<Unit>
    {
        public Guid DeveloperId { get; }

        public string Name { get; }

        public UpdateDeveloperCommand(Guid developerId, string name)
        {
            DeveloperId = developerId;
            Name = name;
        }
    }
}
