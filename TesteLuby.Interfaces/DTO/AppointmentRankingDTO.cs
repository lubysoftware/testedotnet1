using Newtonsoft.Json;
using System;

namespace TesteLuby.Interfaces.DTO
{
    public class AppointmentRankingDTO
    {
        [JsonProperty("date_start")]
        public string Date_Start { get; set; }

        [JsonProperty("date_end")]
        public string Date_End { get; set; }

        [JsonIgnore]
        public DateTime Date_Start_Formated => Convert.ToDateTime(Date_Start);

        [JsonIgnore]
        public DateTime Date_End_Formated => Convert.ToDateTime(Date_End);

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Date_Start))
                return false;

            if (string.IsNullOrEmpty(Date_End))
                return false;

            if (!DateTime.TryParse(Date_Start, out _))
                return false;

            if (!DateTime.TryParse(Date_End, out _))
                return false;

            return true;
        }
    }
}
