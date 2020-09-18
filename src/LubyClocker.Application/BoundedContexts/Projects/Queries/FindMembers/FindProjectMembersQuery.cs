using System;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindMembers
{
    public class FindProjectMembersQuery : PaginatedQuery<ProjectMemberViewModel>
    {
        public Guid ProjectId { get; private set; }
        
        public FindProjectMembersQuery IncludeProjectId(Guid id)
        {
            ProjectId = id;

            return this;
        }
    }
}