using System.Threading.Tasks;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Infrastructure.Persistence;

namespace TimeManager.Infrastructure.Domain.Developers.TimeReports
{
    public class TimeReportRepository : ITimeReportRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TimeReport timeReport)
        {
            _context.TimeReports.Add(timeReport);
            await _context.SaveChangesAsync();
        }
    }
}
