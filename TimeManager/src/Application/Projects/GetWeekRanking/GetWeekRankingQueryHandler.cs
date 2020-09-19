using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeManager.Application.Common.Interfaces;

namespace TimeManager.Application.Projects.GetWeekRanking
{
    public class GetWeekRankingQueryHandler : IRequestHandler<GetWeekRankingQuery, IEnumerable<RankingViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetWeekRankingQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        //@TODO
        public async Task<IEnumerable<RankingViewModel>> Handle(GetWeekRankingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
