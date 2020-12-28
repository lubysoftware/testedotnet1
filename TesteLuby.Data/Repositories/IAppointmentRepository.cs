using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<dynamic> GetRanking(DateTime date_start, DateTime date_end);
    }
}
