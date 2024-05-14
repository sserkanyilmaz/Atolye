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
            
            if (!Guid.TryParse(request.TeamId, out _))
            {
                return new ErrorDataResult<ReportDTO>("TeamId is not a valid GUID.");
            }
            var team = await _queryRepository.Table.Include(t => t.Reports).FirstOrDefaultAsync(u => u.Id == Guid.Parse(request.TeamId));
            
            if (team is null)
            {
                return new ErrorDataResult<ReportDTO>("The team does not exist");
            }

            if (!team.IsActive)
            {
                return new ErrorDataResult<ReportDTO>("The team is not active");
            }
            
            if (string.IsNullOrWhiteSpace(request.TeamId))
            {
                return new ErrorDataResult<ReportDTO>("TeamId cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(request.Content)) 
            {
                return new ErrorDataResult<ReportDTO>("Report content cannot be null or empty.");
            }
            team.Reports.Add(request.Adapt<Report>());
            await _commandRepository.UpdateAsync(team);
            var report = team.Reports.ToList().Last();
            var reportDTO = report.Adapt<ReportDTO>();
            reportDTO.ReportId =report.Id.ToString();
            

            return new DataResult<ReportDTO>(true, reportDTO);
        }
    }
}

