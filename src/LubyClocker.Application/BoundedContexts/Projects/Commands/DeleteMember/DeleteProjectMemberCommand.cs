using System;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.DeleteMember
{
    public class DeleteProjectMemberCommand : Command<bool>
    {
        public Guid ProjectId { get; set; }
        public Guid ProjectMemberId { get; set; }
    }
}