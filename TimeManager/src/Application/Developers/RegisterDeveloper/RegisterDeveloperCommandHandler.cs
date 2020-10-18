using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.RegisterDeveloper
{
    class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, Response>
    {
        private readonly IDeveloperRepository _repository;

        public RegisterDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
        {
            var dev = new Developer(request.Name);

            await _repository.AddAsync(dev);

            return new Response(Unit.Value);
        }
    }
}
