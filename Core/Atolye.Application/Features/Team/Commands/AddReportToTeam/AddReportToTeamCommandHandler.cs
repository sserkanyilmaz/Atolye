using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.AddProjectToTeam;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.AddReportToTeam
{
	public record AddReportToTeamCommandRequest(string TeamId, string Content) : IRequest<IDataResult<ReportDTO>>;

    public class AddReportToTeamCommandHandler : IRequestHandler<AddReportToTeamCommandRequest, IDataResult<ReportDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        public AddReportToTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<IDataResult<ReportDTO>> Handle(AddReportToTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = await _queryRepository.Table.Include(t => t.Reports).FirstOrDefaultAsync(u => u.Id == Guid.Parse(request.TeamId));
            team.Reports.Add(request.Adapt<Report>());
            await _commandRepository.UpdateAsync(team);
            var report = team.Reports.ToList().Last();
            var reportDTO = report.Adapt<ReportDTO>();
            reportDTO.ReportId =report.Id.ToString();
            

            return new DataResult<ReportDTO>(true, reportDTO);
        }
    }
}

