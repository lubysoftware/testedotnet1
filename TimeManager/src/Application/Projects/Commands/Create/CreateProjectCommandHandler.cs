using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
