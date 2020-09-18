using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.RegisterDeveloper
{
    class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public RegisterDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
        {
            var dev = new Developer(request.Name);

            await _repository.AddAsync(dev);

            return Unit.Value;
        }
    }
}
