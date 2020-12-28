using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Services
{
    public class AppointmentService : IAppointmentService
    {
        protected readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool Delete(int id)
        {
            var data = _appointmentRepository.Get(id);

            if (data != null)
                _appointmentRepository.Delete(data);

            return false;
        }

        public AppointmentDTO Get(int id)
        {
            var data = _appointmentRepository.Get(id);

            return new AppointmentDTO(data.DeveloperID, data.Developer.Name, data.ProjectID, data.Project.Name, data.Date_Start.ToString(), data.Date_End.ToString(), data.ID);
        }

        public IEnumerable<dynamic> GetRanking(AppointmentRankingDTO appointmentRankingDTO)
        {
            if (!appointmentRankingDTO.IsValid())
                return Enumerable.Empty<dynamic>();

            return _appointmentRepository.GetRanking(appointmentRankingDTO.Date_Start_Formated, appointmentRankingDTO.Date_End_Formated);
        }

        public bool Insert(AppointmentDTO dto)
        {
            if (!dto.IsValid())
                return false;

            var data = new Appointment(dto.Developer_Id, dto.Project_Id, dto.Date_Start_Formated, dto.Date_End_Formated,null);

            return _appointmentRepository.Insert(data);
        }

        public bool Update(AppointmentDTO dto, int id)
        {
            if (!dto.IsValid())
                return false;

            var appointment = _appointmentRepository.Get(id);

            appointment.SetDateEnd(dto.Date_End_Formated);
            appointment.SetDateStart(dto.Date_Start_Formated);
            appointment.SetDeveloper(dto.Developer_Id);
            appointment.SetProject(dto.Project_Id);

            return _appointmentRepository.Update(appointment);
        }
    }
}
