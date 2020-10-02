using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LaunchTimeRepository : Repository<LaunchTime>, ILaunchTimeRepository
    {
        public LaunchTimeRepository(MyDbContext myDb) : base(myDb)
        {
        }

        public async Task<LaunchTime> GetByIdToRemove(Guid id)
        {
            return await Db.LaunchTimes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
