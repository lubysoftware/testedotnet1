using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Models;
using TimeManager.Domain.Developers;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Domain.Projects;

namespace TimeManager.Application.Developers.TimeReports.SendTimeReport
{
    class SendTimeReportCommandHandler : IRequestHandler<SendTimeReportCommand, Response>
    {
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IProjectRepository _projectRepository;

        public SendTimeReportCommandHandler(ITimeReportRepository timeReportRepository, IDeveloperRepository developerRepository, IProjectRepository projectRepository)
        {
            _timeReportRepository = timeReportRepository;
            _developerRepository = developerRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Response> Handle(SendTimeReportCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            if (request.EndedAt.CompareTo(request.StartedAt) < 0)
            {
                response.AddError("Data final deve ser maior que data inicial.");
                return response;
            }

            // busca dev
            var dev = await _developerRepository.GetByIdsAsync(request.DeveloperId);
            if (dev == null)
            {
                response.AddError("Developer não encontrado");
                return response;
            }

            // busca project
            var project = await _projectRepository.GetByIdsAsync(request.ProjectId);
            if (project == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            var timeReport = new TimeReport(request.DeveloperId, request.ProjectId, request.StartedAt, request.EndedAt);

            await _timeReportRepository.AddAsync(timeReport);

            return new Response(Unit.Value);
        }
    }
}
