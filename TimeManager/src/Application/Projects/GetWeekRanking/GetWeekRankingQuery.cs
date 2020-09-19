using MediatR;
using System.Collections.Generic;

namespace TimeManager.Application.Projects.GetWeekRanking
{
    public class GetWeekRankingQuery : IRequest<IEnumerable<RankingViewModel>>
    {
    }
}
