using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Interfaces;

namespace TimeManager.Application.Projects.Queries
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ProjectsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetProjectsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ProjectsViewModel> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return new ProjectsViewModel
            {
                Projects = await _context.Projects
                    .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Name)
                    .ToListAsync()
            };
        }
    }
}
