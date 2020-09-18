using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.Commands.Delete
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _repository;

        public DeleteDeveloperCommandHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.DeveloperId);

            return Unit.Value;
        }
    }
}
