using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Team.Commands.Delete
{
    public record DeleteTeamCommandRequest(string TeamId) : IRequest<IDataResult<TeamDTO>>;
    public class DeleteTeamCommandHandler: IRequestHandler<DeleteTeamCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        public DeleteTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
        {
            
            if (!Guid.TryParse(request.TeamId, out var _))
            {
                return new ErrorDataResult<TeamDTO>("The provided team ID is not a valid GUID.");
            }
            var team = await _commandRepository.RemoveAsync(request.TeamId);
            
            return new DataResult<TeamDTO>(true, team.Adapt<TeamDTO>());
        }
    }
}

