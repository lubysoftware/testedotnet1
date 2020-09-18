using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Exceptions;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Commands.Update
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.ProjectId);

            if (entity == null)
                throw new NotFoundException(nameof(Project), request.ProjectId);

            entity.ChangeName(request.Name);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
