using System.Threading;
using System.Threading.Tasks;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.Delete
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly LubyClockerContext _context;

        public DeleteProjectCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }

            _context.Projects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}