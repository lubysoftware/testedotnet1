using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Interfaces.DTO
{
    public class AppointmentDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("developer_id")]
        public int Developer_Id { get; set; }

        [JsonIgnore]
        public string DeveloperName { get; set; }

        [JsonProperty("project_id")]
        public int Project_Id { get; set; }

        [JsonIgnore]
        public string ProjectName { get; set; }

        [JsonProperty("date_start")]
        public string Date_Start { get; set; }

        [JsonProperty("date_start")]
        public string Date_End { get; set; }

        [JsonIgnore]
        public DateTime Date_Start_Formated => Convert.ToDateTime(Date_Start);

        [JsonIgnore]
        public DateTime Date_End_Formated => Convert.ToDateTime(Date_End);

        protected AppointmentDTO() { }

        public AppointmentDTO(int developerID, string developerName, int projectID, string projectName, string date_start, string date_end, int? id)
        {
            if (id.HasValue)
                SetID(id.Value);

            SetDeveloper(developerID, developerName);
            SetProject(projectID, projectName);
            SetDateStart(date_start);
            SetDateEnd(date_end);
        }

        public void SetID(int id) => ID = id;

        public void SetDeveloper(int id, string name)
        {
            Developer_Id = id;
            DeveloperName = name;
        }

        public void SetProject(int id, string name)
        {
            Project_Id = id;
            DeveloperName = name;
        }

        public void SetDateStart(string start)
        {
            Date_Start = start;
        }

        public void SetDateEnd(string end)
        {
            Date_End = end;
        }

        public bool IsValid()
        {
            if (Developer_Id <= 0)
                return false;

            if (Project_Id <= 0)
                return false;

            if (string.IsNullOrEmpty(Date_Start))
                return false;

            if (string.IsNullOrEmpty(Date_End))
                return false;

            if (Date_End_Formated < Date_Start_Formated)
                return false;

            return true;
        }
    }
}
