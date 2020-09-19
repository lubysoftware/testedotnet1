using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers.TimeReports;

namespace TimeManager.Application.Developers.TimeReports.SendTimeReport
{
    class SendTimeReportCommandHandler : IRequestHandler<SendTimeReportCommand, Unit>
    {
        private readonly ITimeReportRepository _timeReportRepository;

        public SendTimeReportCommandHandler(ITimeReportRepository timeReportRepository)
        {
            _timeReportRepository = timeReportRepository;
        }

        public async Task<Unit> Handle(SendTimeReportCommand request, CancellationToken cancellationToken)
        {
            var timeReport = new TimeReport(request.DeveloperId, request.ProjectId, request.StartedAt, request.EndedAt);

            await _timeReportRepository.AddAsync(timeReport);

            return Unit.Value;
        }
    }
}
