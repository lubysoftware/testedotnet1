using System;
using TimeManager.Application.Common.Mappers;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects
{
    public class ProjectDto : IMapFrom<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
