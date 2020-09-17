using System;
using TimeManager.Application.Common.Mappings;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Queries
{
    public class ProjectDto : IMapFrom<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
