using System;

namespace TimeManager.Application.Developers.GetWeekRanking
{
    public class RankingViewModel
    {
        public DeveloperDto Developer { get; set; }
        public double SumWorkedWeekHOurs { get; set; }
        public DateTime FirstDayWorked { get; set; }
        public DateTime LastDayWorked { get; set; }
        public double AverageHoursWorked
        {
            get
            {
                var daysWorked = Math.Ceiling((LastDayWorked - FirstDayWorked).TotalDays);
                return SumWorkedWeekHOurs /  daysWorked;
            }
        }
    }
}
