using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.Commands.Delete;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.DeleteMember
{
    public class DeleteProjectMemberCommandHandler : IRequestHandler<DeleteProjectMemberCommand, bool>
    {
        private readonly LubyClockerContext _context;

        public DeleteProjectMemberCommandHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProjectMembers.FirstOrDefaultAsync(p => p.Id == request.ProjectMemberId && p.ProjectId == request.ProjectId, cancellationToken);

            if (entity == null)
            {
                throw new InvalidRequestException(MainResource.ResourceNotExists);
            }

            _context.ProjectMembers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}