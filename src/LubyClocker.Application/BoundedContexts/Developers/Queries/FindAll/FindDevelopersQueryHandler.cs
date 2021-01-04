using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.Infra.Data.Context;
using LubyClocker.Infra.Data.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Developers.Queries.FindAll
{
    public class FindDevelopersQueryHandler : IRequestHandler<FindDevelopersQuery, PaginatedResult<DeveloperViewModel>>
    {
        private readonly LubyClockerContext _context;

        public FindDevelopersQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public Task<PaginatedResult<DeveloperViewModel>> Handle(FindDevelopersQuery request, CancellationToken cancellationToken)
        {
            return _context.Developers
                .AsNoTracking()
                .Select(c => new DeveloperViewModel(c))
                .AsPaginated(request.Page, request.PageSize);
        }
    }
}