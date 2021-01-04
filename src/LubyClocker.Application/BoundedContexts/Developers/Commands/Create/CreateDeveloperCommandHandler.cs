using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.Domain.BoundedContexts.Developers;
using LubyClocker.Infra.Data.Context;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Developers.Commands.Create
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, DeveloperViewModel>
    {
        private readonly LubyClockerContext _context;

        public CreateDeveloperCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<DeveloperViewModel> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var entity = new Developer(
                    request.FullName,
                    request.Commentary,
                    request.Qualification
            );

            await _context.Developers.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new DeveloperViewModel(entity);
        }
    }
}