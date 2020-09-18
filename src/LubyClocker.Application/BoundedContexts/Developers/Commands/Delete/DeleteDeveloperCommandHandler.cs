using System.Threading;
using System.Threading.Tasks;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Developers.Commands.Delete
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, bool>
    {
        private readonly LubyClockerContext _context;

        public DeleteDeveloperCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Developers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }

            _context.Developers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}