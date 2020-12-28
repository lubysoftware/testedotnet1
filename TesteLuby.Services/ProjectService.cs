using System;
using System.Collections.Generic;
using System.Linq;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Services
{
    public class ProjectService : IProjectService
    {
        protected readonly IProjectRepository _projectRepository;
        protected readonly IAppointmentRepository _appointmentRepository;

        public ProjectService(IProjectRepository projectRepository, IAppointmentRepository appointmentRepository)
        {
            _projectRepository = projectRepository;
            _appointmentRepository = appointmentRepository;
        }

        public bool Delete(int id)
        {
            if (_appointmentRepository.FindByQuery(x=> x.ProjectID == id).Any())
                return false;

            var data = _projectRepository.Get(id);

            _projectRepository.Delete(data);

            return true;

        }

        public ProjectDTO Get(int id)
        {
            var data = _projectRepository.Get(id);

            if (data == null)
                return null;

            return new ProjectDTO(data.ID, data.Name, data.Date_Start.ToString(), data.Date_End.ToString());
        }

        public IEnumerable<ProjectDTO> GetByName(string name)
        {
            var data = _projectRepository.FindByName(name);

            if (!data.Any())
                return Enumerable.Empty<ProjectDTO>();

            return data.Select(x => new ProjectDTO(x.ID, x.Name, x.Date_Start.ToString(), x.Date_End.ToString()));
        }

        public bool Insert(ProjectDTO dto)
        {
            if (!dto.IsValid())
                return false;

            var entity = new Project(dto.Name, dto.Date_Start_Formated, dto.Date_End_Formated, null);

            _projectRepository.Insert(entity);

            return true;
        }

        public bool Update(ProjectDTO dto, int id)
        {
            if (!dto.IsValid())
                return false;

            var data = _projectRepository.Get(id);

            data.SetName(dto.Name);
            data.SetDateStart(dto.Date_Start_Formated);
            data.SetDateEnd(dto.Date_End_Formated);

            _projectRepository.Update(data);

            return true;
        }
    }
}
