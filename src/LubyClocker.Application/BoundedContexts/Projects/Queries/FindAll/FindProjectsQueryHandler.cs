using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.Infra.Data.Context;
using LubyClocker.Infra.Data.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindAll
{
    public class FindProjectsQueryHandler : IRequestHandler<FindProjectsQuery, PaginatedResult<ProjectViewModel>>
    {
        private readonly LubyClockerContext _context;

        public FindProjectsQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public Task<PaginatedResult<ProjectViewModel>> Handle(FindProjectsQuery request, CancellationToken cancellationToken)
        {
            return _context.Projects
                .AsNoTracking()
                .Select(c => new ProjectViewModel(c))
                .AsPaginated(request.Page, request.PageSize);
        }
    }
}