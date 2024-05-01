using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.Delete
{
	public record DeleteTeamFromBaseCommandRequest(string TeamId):IRequest<IDataResult<TeamDTO>>;

    public class DeleteTeamFromBaseCommandHandler : IRequestHandler<DeleteTeamFromBaseCommandRequest, IDataResult<TeamDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;

        public DeleteTeamFromBaseCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteTeamFromBaseCommandRequest request, CancellationToken cancellationToken)
        {
            var team = await _commandRepository.RemoveAsync(request.TeamId);
            return new DataResult<TeamDTO>(true, team.Adapt<TeamDTO>());
        }
    }
}

