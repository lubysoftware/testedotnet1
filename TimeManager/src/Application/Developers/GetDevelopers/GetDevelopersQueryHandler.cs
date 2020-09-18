using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;

namespace TimeManager.Application.Developers.GetDevelopers
{
    public class GetDevelopersQueryHandler : IRequestHandler<GetDevelopersQuery, DevelopersViewModel>
    {
        private readonly IDeveloperRepository _repository;

        public GetDevelopersQueryHandler(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<DevelopersViewModel> Handle(GetDevelopersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();

            return new DevelopersViewModel
            {
                Developers = list.Select(x => new DeveloperDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
        }
    }
}
