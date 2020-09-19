using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Developers.SendTimeReport
{
    class SendTimeReportCommandHandler : IRequestHandler<SendTimeReportCommand, Unit>
    {
        private readonly ITimeReportRepository _timeReportRepository;

        // TODO verificar um a um
        private readonly IDeveloperRepository _developerRepository;
        private readonly IProjectRepository _projectRepository;
        // TODO ou verificar com projectmember repository dando include

        public SendTimeReportCommandHandler(ITimeReportRepository timeReportRepository, IDeveloperRepository developerRepository, IProjectRepository projectRepository)
        {
            _timeReportRepository = timeReportRepository;
            _developerRepository = developerRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(SendTimeReportCommand request, CancellationToken cancellationToken)
        {
            var timeReport = new TimeReport(request.ProjectMemberId, request.StartedAt, request.EndedAt);

            await _timeReportRepository.AddAsync(timeReport);

            return Unit.Value;
        }
    }
}
