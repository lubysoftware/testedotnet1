using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.Domain.Entities.TimeSheetNS;
using TimeSheetManager.Domain.TimeSheetNS;

namespace TimeSheetManager.Domain.Repositories {
    public interface ITimeSheetRepository {
        Task Create(TimeSheet timeSheet);
    }
}
