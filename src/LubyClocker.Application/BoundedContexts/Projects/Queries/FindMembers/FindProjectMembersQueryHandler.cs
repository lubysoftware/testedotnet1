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

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindMembers
{
    public class FindProjectMembersQueryHandler : IRequestHandler<FindProjectMembersQuery, PaginatedResult<ProjectMemberViewModel>>
    {
        private readonly LubyClockerContext _context;

        public FindProjectMembersQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<ProjectMemberViewModel>> Handle(FindProjectMembersQuery request, CancellationToken cancellationToken)
        {
            var r = await _context.ProjectMembers
                .AsNoTracking()
                .Where(c => c.ProjectId == request.ProjectId)
                .Include(c => c.Developer)
                .Select(i => new ProjectMemberViewModel
                {
                    Id = i.Id,
                    CreatedAt = i.CreatedAt,
                    EntryDate = i.EntryDate,
                    Developer = new DeveloperViewModel()
                    {
                        Id = i.Developer.Id,
                        Commentary = i.Developer.Commentary,
                        FullName = i.Developer.FullName,
                        Qualification = i.Developer.Qualification,
                        CreatedAt = i.Developer.CreatedAt
                    }
                })
                .AsPaginated(request.Page, request.PageSize);
            
            return r;
        }
    }
}