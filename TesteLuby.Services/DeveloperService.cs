using System.Collections.Generic;
using TesteLuby.Data.Repositories;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;
using System.Linq;
using TesteLuby.Data.Entities;

namespace TesteLuby.Services
{
    public class DeveloperService : IDeveloperService
    {
        protected readonly IDeveloperRepository _developerRepository;
        protected readonly IAppointmentRepository _appointmentRepository;

        public DeveloperService(IDeveloperRepository developerRepository, IAppointmentRepository appointmentRepository)
        {
            _developerRepository = developerRepository;
            _appointmentRepository = appointmentRepository;
        }

        public bool Delete(int id)
        {
            if (_appointmentRepository.FindByQuery(x => x.DeveloperID == id).Any())
                return false;

            var data = _developerRepository.Get(id);

            _developerRepository.Delete(data);

            return true;
        }

        public DeveloperDTO Get(int id)
        {
            var data = _developerRepository.Get(id);

            if (data == null)
                return null;

            return new DeveloperDTO(data.ID, data.Name);
        }

        public IEnumerable<DeveloperDTO> GetByName(string name)
        {
            var data = _developerRepository.FindByName(name);

            if (!data.Any())
                return Enumerable.Empty<DeveloperDTO>();

            return data.Select(x => new DeveloperDTO(x.ID, x.Name));
        }

        public bool Insert(DeveloperDTO dto)
        {
            if (!dto.IsValid())
                return false;

            var entity = new Developer(dto.Name, null);
            _developerRepository.Insert(entity);

            return true;
        }

        public bool Update(DeveloperDTO dto, int id)
        {
            if (!dto.IsValid())
                return false;

            var data = _developerRepository.Get(id);

            data.SetName(dto.Name);

            _developerRepository.Update(data);

            return true;
        }
    }
}
