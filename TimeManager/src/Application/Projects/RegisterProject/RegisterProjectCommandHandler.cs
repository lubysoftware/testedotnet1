using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.RegisterProject
{
    public class RegisterProjectCommandHandler : IRequestHandler<RegisterProjectCommand, Response>
    {
        private readonly IProjectRepository _repository;

        public RegisterProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(RegisterProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name);

            await _repository.AddAsync(project);

            return new Response(Unit.Value);
        }
    }
}
