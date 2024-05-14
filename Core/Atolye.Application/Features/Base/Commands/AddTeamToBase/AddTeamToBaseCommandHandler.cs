using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Commands.AddTeamToBase
{
	public record AddTeamToBaseCommandRequest(string TeamID, string BaseID) : IRequest<IDataResult<BaseDto>>;
    public class AddTeamToBaseCommandHandler : IRequestHandler<AddTeamToBaseCommandRequest, IDataResult<BaseDto>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        IQueryRepository<Domain.Entities.Base> _basequeryRepository;

        public AddTeamToBaseCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository, IQueryRepository<Domain.Entities.Base> basequeryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _basequeryRepository = basequeryRepository;
        }

        public async Task<IDataResult<BaseDto>> Handle(AddTeamToBaseCommandRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.BaseID, out _))
            {
                return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
            }
            if (!Guid.TryParse(request.TeamID, out _))
            {
                return new ErrorDataResult<BaseDto>("TeamId is not a valid GUID.");
            }
            if (string.IsNullOrEmpty(request.TeamID) || string.IsNullOrEmpty(request.BaseID))
            {
                return new DataResult<BaseDto>("Invalid parameters provided.",false, new BaseDto { });
            }

            var team = await _queryRepository.Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.TeamID));
            var baseEntity = await _basequeryRepository.Table.FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseID));

            if (team == null || !team.IsActive || baseEntity == null || !baseEntity.IsActive)
            {
                return new DataResult<BaseDto>("Team or Base does not exist or is not active.",false, new BaseDto { });
            }
            team.BaseId = Guid.Parse(request.BaseID);
            await _commandRepository.UpdateAsync(team);
            
            var Base = await _basequeryRepository.Table.Include(t => t.Teams)
                .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseID));
            return new DataResult<BaseDto>(true, Base.Adapt<BaseDto>());
        }
    }
}

