using System.Threading.Tasks;
using TimeManager.Domain.Projects.ProjectMembers;
using TimeManager.Infrastructure.Persistence;

namespace TimeManager.Infrastructure.Domain.Projects.ProjectMembers
{
    public class ProjectMemberRepository : IProjectMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProjectMember projectMember)
        {
            _context.ProjectMembers.Add(projectMember);
            await _context.SaveChangesAsync();
        }
    }
}
