using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.ChangeDeveloperDetails
{
    public class ChangeDeveloperDetailsCommandHandler : IRequestHandler<ChangeDeveloperDetailsCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public ChangeDeveloperDetailsCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeDeveloperDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdsAsync(request.DeveloperId);

            // TODO verify if null

            entity.ChangeName(request.Name);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
