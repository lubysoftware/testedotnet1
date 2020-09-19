using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeManager.Domain.Developers.TimeReports
{
    public interface ITimeReportRepository
    {
        Task AddAsync(TimeReport timeReport);
    }
}
