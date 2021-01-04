using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Developers.Commands.Update
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, DeveloperViewModel>
    {
        private readonly LubyClockerContext _context;

        public UpdateDeveloperCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<DeveloperViewModel> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Developers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }
            
            entity.Commentary = request.Commentary;
            entity.FullName = request.FullName;
            entity.Qualification = request.Qualification;

            _context.Developers.Update(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return new DeveloperViewModel(entity);
        }
    }
}