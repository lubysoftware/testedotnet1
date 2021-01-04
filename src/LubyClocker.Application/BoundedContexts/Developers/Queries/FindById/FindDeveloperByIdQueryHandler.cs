using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Developers.Queries.FindById
{
    public class FindDeveloperByIdQueryHandler : IRequestHandler<FindDeveloperByIdQuery, DeveloperViewModel>
    {
        private readonly LubyClockerContext _context;

        public FindDeveloperByIdQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<DeveloperViewModel> Handle(FindDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Developers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }
            
            return new DeveloperViewModel(entity);
        }
    }
}