using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.AddReportToTeam;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.Update
{
	public record UpdateTeamCommandRequest(string TeamId, string TeamName): IRequest<IDataResult<TeamDTO>>; 

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        public UpdateTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = await _queryRepository.Table.FirstOrDefaultAsync(u => u.Id == Guid.Parse(request.TeamId));
            team.Name = request.TeamName;
            await _commandRepository.UpdateAsync(team);
            return new DataResult<TeamDTO>(true, team.Adapt<TeamDTO>());

        }
    }
}

