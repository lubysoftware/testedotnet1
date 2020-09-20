using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.CancelProject
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Response>
    {
        private readonly IProjectRepository _repository;

        public CancelProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            var entity = await _repository.GetByIdsAsync(request.ProjectId);
            if (entity == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            await _repository.DeleteAsync(request.ProjectId);

            return new Response(Unit.Value);
        }
    }
}
