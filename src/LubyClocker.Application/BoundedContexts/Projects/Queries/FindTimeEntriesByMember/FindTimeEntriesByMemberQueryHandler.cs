using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.Infra.Data.Context;
using LubyClocker.Infra.Data.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindTimeEntriesByMember
{
    public class FindTimeEntriesByMemberQueryHandler : IRequestHandler<FindTimeEntriesByMemberQuery, PaginatedResult<TimeEntryViewModel>>
    {
        private readonly LubyClockerContext _context;

        public FindTimeEntriesByMemberQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public Task<PaginatedResult<TimeEntryViewModel>> Handle(FindTimeEntriesByMemberQuery request,
            CancellationToken cancellationToken)
        {
            return _context.TimeEntries
                .AsNoTracking()
                .Where(c => c.ProjectMemberId == request.ProjectMemberId &&
                            c.ProjectMember.ProjectId == request.ProjectId)
                .Include(c => c.ProjectMember)
                .ThenInclude(c => c.Developer)
                .Select(t => new TimeEntryViewModel()
                {
                    Id = t.Id,
                    End = t.End,
                    Start = t.Start,
                    CreatedAt = t.CreatedAt,
                    WorkedTime = t.WorkedTime,
                    ProjectMember = new ProjectMemberViewModel
                    {
                        Id = t.ProjectMember.Id,
                        CreatedAt = t.ProjectMember.CreatedAt,
                        EntryDate = t.ProjectMember.EntryDate,
                        Developer = new DeveloperViewModel()
                        {
                            Id = t.ProjectMember.Developer.Id,
                            Commentary = t.ProjectMember.Developer.Commentary,
                            FullName = t.ProjectMember.Developer.FullName,
                            Qualification = t.ProjectMember.Developer.Qualification,
                            CreatedAt = t.ProjectMember.Developer.CreatedAt
                        }
                    }
                })
                .AsPaginated(request.Page, request.PageSize);
        }
    }
}