using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.AddTeamToBase
{
	public record AddTeamCommandRequest(string TeamID, string BaseID) : IRequest<IDataResult<TeamDTO>>;
    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommandRequest, IDataResult<TeamDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;

        public AddTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(AddTeamCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(request.Adapt<Domain.Entities.Team>());
            await _commandRepository.SaveAsync();
            return new DataResult<TeamDTO>(true, request.Adapt<TeamDTO>());
        }
    }
}

