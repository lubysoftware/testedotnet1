using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects.ProjectMembers;

namespace TimeManager.Application.Projects.RegisterMember
{
    public class RegisterProjectMemberCommandHandler : IRequestHandler<RegisterProjectMemberCommand, Unit>
    {
        private readonly IProjectMemberRepository _repository;

        public RegisterProjectMemberCommandHandler(IProjectMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var projectMember = new ProjectMember(request.DeveloperId, request.ProjectId);

            await _repository.AddAsync(projectMember);

            return Unit.Value;
        }
    }
}
