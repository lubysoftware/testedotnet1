using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Interfaces
{
    public interface IAppointmentService : IBaseService<AppointmentDTO>
    {
        IEnumerable<dynamic> GetRanking(AppointmentRankingDTO appointmentRankingDTO);
    }
}
