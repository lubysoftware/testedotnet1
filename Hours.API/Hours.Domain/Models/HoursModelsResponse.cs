using System;

namespace Hours.Domain.Models
{
    public class HoursModelsResponse
    {
        public string Developer { get; set; }
        public TimeSpan HoursWorkedInTheWeek { get; set; }
        public string TotalOfHoursWorked
        {
            get
            {
                return HoursWorkedInTheWeek.Hours + ":" + HoursWorkedInTheWeek.Minutes + ":" + HoursWorkedInTheWeek.Seconds;
            }
        }
        public TimeSpan AverageWorked { get; set; }
        public string AverageHoursWorked
        {
            get
            {
                return AverageWorked.Hours + ":" + AverageWorked.Minutes + ":" + AverageWorked.Seconds;
            }
        }
    }
}
