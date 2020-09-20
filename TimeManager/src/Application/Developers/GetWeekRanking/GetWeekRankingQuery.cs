using MediatR;
using System.Collections.Generic;

namespace TimeManager.Application.Developers.GetWeekRanking
{
    public class GetWeekRankingQuery : IRequest<IEnumerable<RankingViewModel>>
    {
    }
}
