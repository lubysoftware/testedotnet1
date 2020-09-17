using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Project> Projects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
