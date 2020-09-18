using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Commands.Update
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdsAsync(request.ProjectId);

            // TODO verify if null

            entity.ChangeName(request.Name);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
