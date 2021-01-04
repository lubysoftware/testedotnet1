using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindWeekRanking
{
    public class
        FindDevelopersWeekRankingQueryHandler : IRequestHandler<FindDevelopersWeekRankingQuery,
            IEnumerable<WeekRankingViewModel>>
    {
        private readonly LubyClockerContext _context;

        public FindDevelopersWeekRankingQueryHandler(LubyClockerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeekRankingViewModel>> Handle(FindDevelopersWeekRankingQuery request,
            CancellationToken cancellationToken)
        {
            var endDay = DateTime.Now.Date;
            var startDay = endDay;
            var diffDays = 1;

            while (startDay.DayOfWeek != DayOfWeek.Monday)
            {
                startDay = startDay.AddDays(-1);
            }

            diffDays = (endDay - startDay).Days + 1;

            var weekEntries = await _context.TimeEntries
                .Include(c => c.ProjectMember)
                .ThenInclude(c => c.Developer)
                .Where(c => c.Start.Date >= startDay && c.End <= endDay)
                .ToListAsync(CancellationToken.None);

            var list = from timeEntry in weekEntries
                group timeEntry by timeEntry.ProjectMember.Developer
                into g
                select new WeekRankingViewModel()
                {
                    Developer = new DeveloperViewModel()
                    {
                        Id = g.Key.Id,
                        CreatedAt = g.Key.CreatedAt,
                        Commentary = g.Key.Commentary,
                        Qualification = g.Key.Qualification,
                        FullName = g.Key.FullName
                    },
                    WeekAverage = TimeSpan.FromSeconds(g.Average(c => c.WorkedTime.TotalSeconds) / diffDays)
                };

            return list
                .OrderByDescending(c => c.WeekAverage)
                .Take(5);
        }
    }
}