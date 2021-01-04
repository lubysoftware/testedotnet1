using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Domain.BoundedContexts.Projects;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.CreateTimeEntry
{
    public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, TimeEntryViewModel>
    {
        private readonly LubyClockerContext _context;

        public CreateTimeEntryCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<TimeEntryViewModel> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var projectMember = await _context.ProjectMembers.SingleOrDefaultAsync(p => p.ProjectId == request.ProjectId && p.Id == request.ProjectMemberId, cancellationToken: cancellationToken);

            if (projectMember == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }

            var entity = new TimeEntry(request.Start, request.End, projectMember.Id);

            await _context.TimeEntries.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            var persistedEntity = await _context.TimeEntries
                .Include(c => c.ProjectMember)
                .ThenInclude(c => c.Developer)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == entity.Id, cancellationToken: cancellationToken);
                
            return new TimeEntryViewModel(persistedEntity);
        }
    }
}