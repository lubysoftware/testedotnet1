using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.Commands.Create
{
    class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public CreateDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var dev = new Developer(request.Name);

            await _repository.AddAsync(dev);

            return Unit.Value;
        }
    }
}
