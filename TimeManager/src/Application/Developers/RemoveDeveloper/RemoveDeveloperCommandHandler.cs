using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.RemoveDeveloper
{
    public class RemoveDeveloperCommandHandler : IRequestHandler<RemoveDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public RemoveDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveDeveloperCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.DeveloperId);

            return Unit.Value;
        }
    }
}
