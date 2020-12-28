using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteLuby.Data.Context;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;
using TesteLuby.Repository.Base;

namespace TesteLuby.Repository.Appointments
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        protected readonly IDeveloperRepository _developerRepository;
        protected readonly IProjectRepository _projectRepository;

        public AppointmentRepository(DbContextData dbContextData, IDeveloperRepository developerRepository, IProjectRepository projectRepository)
            : base(dbContextData)
        {
            _developerRepository = developerRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<dynamic> GetRanking(DateTime date_start, DateTime date_end)
        {
            var appointments = _dbContextData.Appointments.Where(x => x.Date_Start >= date_start && x.Date_End <= date_end)
                                                          .Include(x => x.Developer)
                                                          .AsEnumerable()   
                                                          .GroupBy(x => x.Developer.Name, c => c)
                                                          .Select(x => new
                                                          {
                                                              DeveloperName = x.Key,
                                                              Average = x.Average(f => (f.Date_End - f.Date_Start).TotalHours),
                                                          })
                                                          .OrderByDescending(x => x.Average)
                                                          .Take(5)
                                                          .ToList();


            return appointments;
        }

        public override Appointment Get(int id)
        {
            return _dbContextData.Appointments.Where(x => x.ID == id).Include(x => x.Developer).Include(x => x.Project).FirstOrDefault();
        }

        public override bool Insert(Appointment entity)
        {
            if (_projectRepository.Get(entity.ProjectID) == null)
                return false;

            if (_developerRepository.Get(entity.DeveloperID) == null)
                return false;

            return base.Insert(entity);
        }

        public override bool Update(Appointment entity)
        {
            if (_projectRepository.Get(entity.ProjectID) == null)
                return false;

            if (_developerRepository.Get(entity.DeveloperID) == null)
                return false;

            return base.Update(entity);
        }
    }
}
