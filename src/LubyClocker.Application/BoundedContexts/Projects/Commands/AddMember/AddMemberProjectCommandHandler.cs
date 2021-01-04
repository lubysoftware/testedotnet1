using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.Domain.BoundedContexts.Projects;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.AddMember
{
    public class AddMemberProjectCommandHandler : IRequestHandler<AddMemberProjectCommand, ProjectMemberViewModel>
    {
        private readonly LubyClockerContext _context;

        public AddMemberProjectCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<ProjectMemberViewModel> Handle(AddMemberProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProjectMember(
                request.EntryDate,
                request.DeveloperId,
                request.ProjectId
            );

            await _context.ProjectMembers.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            var persistedEntity = await _context.ProjectMembers
                .Include(c => c.Developer)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == entity.Id, cancellationToken: cancellationToken);
                
            return new ProjectMemberViewModel(persistedEntity);
        }
    }
}