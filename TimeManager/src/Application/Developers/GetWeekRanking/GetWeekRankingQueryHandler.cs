using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Application.Common.Models;
using TimeManager.Domain;

namespace TimeManager.Application.Developers.GetWeekRanking
{
    public class GetWeekRankingQueryHandler : IRequestHandler<GetWeekRankingQuery, Response>
    {
        private readonly IApplicationDbContext _context;

        public GetWeekRankingQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(GetWeekRankingQuery request, CancellationToken cancellationToken)
        {
            var thisWeek = DateTime.Now.WeekNumberOfTheYear();

            var queryResult = await _context.TimeReports
                .Include(l => l.Developer)
                .GroupBy(d => new { d.Developer.Name, d.DeveloperId, d.CalculatedWeekOfTheYear })
                .Where(w => w.Key.CalculatedWeekOfTheYear == thisWeek)
                .Select(s => new RankingViewModel
                {
                    Developer = new DeveloperDto
                    {
                        Id = s.Key.DeveloperId,
                        Name = s.Key.Name,
                    },
                    WorkedTimeSum = TimeSpan.FromSeconds(s.Sum(p => p.CalculatedTimeWorked.TotalSeconds)),
                    WorkedTimeAverage = TimeSpan.FromSeconds(s.Average(a => a.CalculatedTimeWorked.TotalSeconds))
                })
                .OrderByDescending(o => o.WorkedTimeSum)
                .Take(5)
                .ToListAsync();

            return new Response(queryResult);
        }
    }
}
