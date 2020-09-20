using System;

namespace TimeManager.Application.Developers.GetWeekRanking
{
    public class RankingViewModel
    {
        public DeveloperDto Developer { get; set; }
        public TimeSpan WorkedTimeSum { get; set; }
        public TimeSpan WorkedTimeAverage { get; set; }
    }
}
