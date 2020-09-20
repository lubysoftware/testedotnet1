using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.RemoveDeveloper
{
    public class RemoveDeveloperCommandHandler : IRequestHandler<RemoveDeveloperCommand, Response>
    {
        private readonly IDeveloperRepository _repository;

        public RemoveDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(RemoveDeveloperCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            var entity = await _repository.GetByIdsAsync(request.DeveloperId);
            if (entity == null)
            {
                response.AddError("Developer não encontrado");
                return response;
            }

            await _repository.DeleteAsync(request.DeveloperId);

            return new Response(Unit.Value);
        }
    }
}
