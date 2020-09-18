using System;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindTimeEntriesByMember
{
    public class FindTimeEntriesByMemberQuery : PaginatedQuery<TimeEntryViewModel>
    {
        public Guid ProjectMemberId { get; private set; }
        public Guid ProjectId { get; private set; }

        public FindTimeEntriesByMemberQuery(Guid projectMemberId, Guid projectId)
        {
            ProjectMemberId = projectMemberId;
            ProjectId = projectId;
        }
    }
}