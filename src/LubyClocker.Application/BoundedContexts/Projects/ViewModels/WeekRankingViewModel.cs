using System;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;

namespace LubyClocker.Application.BoundedContexts.Projects.ViewModels
{
    public class WeekRankingViewModel
    {
        public DeveloperViewModel Developer { get; set; }
        public TimeSpan WeekAverage { get; set; }
    }
}