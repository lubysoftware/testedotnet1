using System;
using TimeManager.Application.Developers;

namespace TimeManager.Application.Projects.GetWeekRanking
{
    public class RankingViewModel
    {
        public DeveloperDto Developer { get; set; }
        public TimeSpan WorkedTimeSum { get; set; }
    }
}
