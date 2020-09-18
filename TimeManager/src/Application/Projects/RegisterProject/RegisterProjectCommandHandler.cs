using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.RegisterProject
{
    public class RegisterProjectCommandHandler : IRequestHandler<RegisterProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public RegisterProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name);

            await _repository.AddAsync(project);

            return Unit.Value;
        }
    }
}
