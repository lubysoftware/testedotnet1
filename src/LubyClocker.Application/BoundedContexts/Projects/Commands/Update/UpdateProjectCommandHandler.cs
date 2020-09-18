using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.Update
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ProjectViewModel>
    {
        private readonly LubyClockerContext _context;

        public UpdateProjectCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<ProjectViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }
            
            entity.Name = request.Name;
            entity.StartDate = request.StartDate;
            entity.DeliveryDate = request.DeliveryDate;
            entity.Description = request.Description;

            _context.Projects.Update(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return new ProjectViewModel(entity);
        }
    }
}