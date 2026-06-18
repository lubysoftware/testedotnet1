using System;

namespace Hours.Domain.DTO
{
    public class HoursDTO
    {
        public string Developer { get; set; }
        public TimeSpan HoursWorkedInTheWeek { get; set; }
        public TimeSpan TotalOfHoursWorked
        {
            get
            {
                return new TimeSpan(HoursWorkedInTheWeek.Hours, HoursWorkedInTheWeek.Minutes, HoursWorkedInTheWeek.Seconds);
                            }
        }
        public TimeSpan AverageWorked { get; set; }
        public TimeSpan AverageHoursWorked
        {
            get
            {
                return new TimeSpan(AverageWorked.Hours, AverageWorked.Minutes, AverageWorked.Seconds);
            }
        }
    }
}
