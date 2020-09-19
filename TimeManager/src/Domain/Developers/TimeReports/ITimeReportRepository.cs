using System.Threading.Tasks;

namespace TimeManager.Domain.Developers.TimeReports
{
    public interface ITimeReportRepository
    {
        Task AddAsync(TimeReport timeReport);
    }
}
