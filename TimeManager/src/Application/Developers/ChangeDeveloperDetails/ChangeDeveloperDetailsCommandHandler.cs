using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.ChangeDeveloperDetails
{
    public class ChangeDeveloperDetailsCommandHandler : IRequestHandler<ChangeDeveloperDetailsCommand, Response>
    {
        private readonly IDeveloperRepository _repository;

        public ChangeDeveloperDetailsCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(ChangeDeveloperDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            var entity = await _repository.GetByIdsAsync(request.DeveloperId);
            if(entity == null)
            {
                response.AddError("Developer não encontrado");
                return response;
            }

            entity.ChangeName(request.Name);

            await _repository.UpdateAsync(entity);

            return new Response(Unit.Value);
        }
    }
}
