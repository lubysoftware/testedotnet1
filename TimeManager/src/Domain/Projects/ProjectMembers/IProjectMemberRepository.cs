using System.Threading.Tasks;

namespace TimeManager.Domain.Projects.ProjectMembers
{
    public interface IProjectMemberRepository
    {
        Task AddAsync(ProjectMember projectMember);
    }
}
