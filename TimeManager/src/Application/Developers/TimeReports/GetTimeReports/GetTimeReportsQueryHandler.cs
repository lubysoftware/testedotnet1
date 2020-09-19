using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeManager.Application.Common.Interfaces;

namespace TimeManager.Application.Developers.TimeReports.GetTimeReports
{
    public class GetTimeReportsQueryHandler : IRequestHandler<GetTimeReportsQuery, TimeReportsViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetTimeReportsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TimeReportsViewModel> Handle(GetTimeReportsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.TimeReports
                .Where(w => w.DeveloperId == request.DeveloperId)
                .Select(s => new TimeReportDto
                {
                    Id = s.Id,
                    DeveloperId = s.DeveloperId,
                    ProjectId = s.ProjectId,
                    EndedAt = s.EndedAt,
                    StartedAt = s.StartedAt,
                    CalculatedTimeWorked = s.CalculatedTimeWorked
                }).ToListAsync();

            var s = new TimeReportsViewModel
            {
                TimeReports = result
            };

            return s;
        }
    }
}
