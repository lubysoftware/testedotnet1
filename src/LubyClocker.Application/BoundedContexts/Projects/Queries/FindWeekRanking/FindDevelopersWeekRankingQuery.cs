using System.Collections.Generic;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindWeekRanking
{
    public class FindDevelopersWeekRankingQuery : Query<IEnumerable<WeekRankingViewModel>>
    {
    }
}