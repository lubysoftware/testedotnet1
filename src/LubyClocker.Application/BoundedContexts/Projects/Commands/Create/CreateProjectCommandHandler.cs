using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.Domain.BoundedContexts.Projects;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectViewModel>
    {
        private readonly LubyClockerContext _context;

        public CreateProjectCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<ProjectViewModel> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project(
                    request.Name,
                    request.StartDate,
                    request.DeliveryDate,
                    request.Description
            );

            await _context.Projects.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new ProjectViewModel(entity);
        }
    }
}