using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindById
{
    public class FindProjectByIdQueryHandler : IRequestHandler<FindProjectByIdQuery, ProjectViewModel>
    {
        private readonly LubyClockerContext _context;

        public FindProjectByIdQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<ProjectViewModel> Handle(FindProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }
            
            return new ProjectViewModel(entity);
        }
    }
}