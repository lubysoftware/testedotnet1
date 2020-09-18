using MediatR;
using System;

namespace TimeManager.Application.Projects.ChangeProjectDetails
{
    public class ChangeProjectDetailsCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }
        public string Name { get; }

        public ChangeProjectDetailsCommand(Guid id, string name)
        {
            ProjectId = id;
            Name = name;
        }
    }
}
