using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Exceptions;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Commands.Delete
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {

        private readonly IApplicationDbContext _context;

        public DeleteProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.Where(p => p.Id == request.ProjectId).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            _context.Projects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
