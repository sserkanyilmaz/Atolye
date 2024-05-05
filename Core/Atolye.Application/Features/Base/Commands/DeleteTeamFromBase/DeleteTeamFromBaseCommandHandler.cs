using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.DeleteTeamFrom
{
	public record DeleteTeamFromBaseCommandRequest(string TeamId , string BaseId):IRequest<IDataResult<BaseDto>>;

    public class DeleteTeamFromBaseCommandHandler : IRequestHandler<DeleteTeamFromBaseCommandRequest, IDataResult<BaseDto>>
    {
        ICommandRepository<Domain.Entities.Base> _baseCommandRepository;
        IQueryRepository<Domain.Entities.Base> _baseQueryRepository;
        ICommandRepository<Domain.Entities.Team> _teamCommandRepository;
        IQueryRepository<Domain.Entities.Team> _teamQueryRepository;

        public DeleteTeamFromBaseCommandHandler(ICommandRepository<Domain.Entities.Base> baseCommandRepository, ICommandRepository<Domain.Entities.Team> teamCommandRepository, IQueryRepository<Domain.Entities.Base> baseQueryRepository, IQueryRepository<Domain.Entities.Team> teamQueryRepository)
        {
            _baseCommandRepository = baseCommandRepository;
            _baseQueryRepository = baseQueryRepository;
            _teamQueryRepository = teamQueryRepository;
            _teamCommandRepository = teamCommandRepository;
        }
        public async Task<IDataResult<BaseDto>> Handle(DeleteTeamFromBaseCommandRequest request, CancellationToken cancellationToken)
        {
            
            var team = await _teamQueryRepository.GetByIdAsync(request.TeamId);
            team.BaseId = null;
            await _teamCommandRepository.UpdateAsync(team);
            var baseDTO = (await _baseQueryRepository.GetByIdAsync(request.BaseId)).Adapt<BaseDto>();
            return new SuccessDataResult<BaseDto>("Team's base has been successfully set to null",baseDTO);
        }
    }
}

