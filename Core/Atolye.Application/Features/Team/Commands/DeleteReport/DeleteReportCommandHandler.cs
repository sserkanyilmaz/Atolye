using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.DeleteProject;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Team.Commands.DeleteReport
{
    public record DeleteReportCommandRequest(string TeamId, string ReportId) : IRequest<IDataResult<TeamDTO>>;

    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _teamQueryRepository;
        ICommandRepository<Domain.Entities.Team> _teamCommandRepository;
        ICommandRepository<Report> _reportCommandRepository;
        IQueryRepository<Report> _reportQueryRepository;
        public DeleteReportCommandHandler(IQueryRepository<Domain.Entities.Team> teamQueryRepository, ICommandRepository<Domain.Entities.Team> teamCommandRepository, ICommandRepository<Report> reportCommandRepository, IQueryRepository<Report> reportQueryRepository)
        {
            _teamQueryRepository = teamQueryRepository;
            _teamCommandRepository = teamCommandRepository;
            _reportCommandRepository = reportCommandRepository;
            _reportQueryRepository = reportQueryRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteReportCommandRequest request, CancellationToken cancellationToken)
        {
            var report = await _reportQueryRepository.GetByIdAsync(request.ReportId);
            report.Team = null;
            report.TeamId = null;
            await _reportCommandRepository.UpdateAsync(report);
            var team = await _teamQueryRepository.GetByIdAsync(request.TeamId);
            var teamDTO = team.Adapt<TeamDTO>();
            return new DataResult<TeamDTO>(true, teamDTO);
        }
    }
}

