using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.Commands.Update
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public UpdateDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdsAsync(request.DeveloperId);

            // TODO verify if null

            entity.ChangeName(request.Name);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
