using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteLuby.Data.Entities
{
    public class Project : Entity
    {
        public string Name { get; private set; }

        public DateTime Date_Start { get; private set; }

        public DateTime Date_End { get; private set; }

        public List<Appointment> Appointments { get; private set; }

        protected Project() { }

        public Project(string name, DateTime date_start, DateTime date_end, int? id, List<Appointment> appointments = null)
        {
            SetName(name);
            SetDateStart(date_start);
            SetDateEnd(date_end);

            if (id.HasValue)
                SetID(id.Value);

            if (appointments != null)
                SetAppointments(appointments);
        }


        public void SetName(string name) => Name = name;
        public void SetDateStart(DateTime dateStart) => Date_Start = dateStart;
        public void SetDateEnd(DateTime dateEnd) => Date_End = dateEnd;
        public void SetAppointments(List<Appointment> appointments) => Appointments = appointments;
    }
}
