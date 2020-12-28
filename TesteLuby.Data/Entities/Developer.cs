using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Data.Entities
{
    public class Developer : Entity
    {
        public string Name { get; private set; }

        public List<Appointment> Appointments { get; private set; }

        protected Developer() { }

        public Developer(string name, int? id, List<Appointment> appointments = null)
        {
            SetName(name);

            if (id.HasValue)
                SetID(id.Value);

            if (appointments != null)
                SetAppointments(appointments);
        }

        public void SetName(string name) => Name = name.ToUpper();

        public void SetAppointments(List<Appointment> appointments) => Appointments = appointments; 
    }
}
