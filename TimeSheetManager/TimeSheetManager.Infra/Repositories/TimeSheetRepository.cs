using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.App.Commands.TimeSheet;
using TimeSheetManager.Domain;
using TimeSheetManager.Domain.Entities.TimeSheetNS;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Domain.TimeSheetNS;
using TimeSheetManager.Infra.Context;

namespace TimeSheetManager.Infra.Repositories {
    public class TimeSheetRepository : ITimeSheetRepository {
        private readonly DataContext _context;
        public TimeSheetRepository(DataContext context) {
            _context = context;
        }

        public async Task Create(TimeSheet timeSheet) {
            _context.TimeSheet.Add(timeSheet);
            await _context.SaveChangesAsync();
        }
    }
}
