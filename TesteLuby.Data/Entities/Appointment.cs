using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Data.Entities
{
    public class Appointment : Entity
    {
        public DateTime Date_Start { get; private set; }

        public DateTime Date_End { get; private set; }

        public int ProjectID { get; private set; }

        public Project Project { get; private set; }

        public int DeveloperID { get; private set; }
        public Developer Developer { get; private set; }

        protected Appointment() { }

        public Appointment(int developerID, int projectID, DateTime date_start, DateTime date_end, int? id)
        {
            if (id.HasValue)
                SetID(id.Value);

            SetDeveloper(developerID);
            SetProject(projectID);
            SetDateStart(date_start);
            SetDateEnd(date_end);
        }

        public void SetDeveloper(int id) => DeveloperID = id;

        public void SetProject(int id) => ProjectID = id;

        public void SetDateStart(DateTime start) => Date_Start = start;

        public void SetDateEnd(DateTime end) => Date_End = end;
    }
}
