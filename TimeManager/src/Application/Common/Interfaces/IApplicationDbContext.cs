using Microsoft.EntityFrameworkCore;
using TimeManager.Domain.Developers;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<TimeReport> TimeReports { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
