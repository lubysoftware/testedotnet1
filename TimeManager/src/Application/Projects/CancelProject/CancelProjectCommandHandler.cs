using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.CancelProject
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public CancelProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ProjectId);

            return Unit.Value;
        }
    }
}
