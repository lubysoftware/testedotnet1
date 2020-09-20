using MediatR;
using System;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Projects.ChangeProjectDetails
{
    public class ChangeProjectDetailsCommand : IRequest<Response>
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
