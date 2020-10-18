using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.ChangeProjectDetails
{
    public class ChangeProjectDetailsCommandHandler : IRequestHandler<ChangeProjectDetailsCommand, Response>
    {
        private readonly IProjectRepository _repository;

        public ChangeProjectDetailsCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(ChangeProjectDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var entity = await _repository.GetByIdsAsync(request.ProjectId);

            if (entity == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            entity.ChangeName(request.Name);

            await _repository.UpdateAsync(entity);

            return new Response(Unit.Value);
        }
    }
}
