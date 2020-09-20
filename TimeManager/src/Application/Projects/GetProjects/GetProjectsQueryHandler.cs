using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Projects.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, Response>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();

            var result =  new ProjectsViewModel
            {
                Projects = list.Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };

            return new Response(result);
        }
    }
}
