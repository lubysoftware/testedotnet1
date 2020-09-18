using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.Queries
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ProjectsViewModel>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectsViewModel> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();

            return new ProjectsViewModel
            {
                Projects = list.Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
        }
    }
}
