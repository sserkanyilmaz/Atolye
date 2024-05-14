using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.AddInventoryToTeam
{
    public record AddConsumableInventoryTeamCommandRequest(string TeamId,string Name, int Quantity, string Details)  :IRequest<IDataResult<ConsumableInventoryDTO>>;

    public class AddConsumableInventoryToTeamCommandHandler : IRequestHandler<AddConsumableInventoryTeamCommandRequest, IDataResult<ConsumableInventoryDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        public AddConsumableInventoryToTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<IDataResult<ConsumableInventoryDTO>> Handle(AddConsumableInventoryTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = await _queryRepository.Table.Include(t=>t.ConsumableInventory).FirstOrDefaultAsync(u=>u.Id == Guid.Parse(request.TeamId));
           

            if (team == null)
            {
                return new ErrorDataResult<ConsumableInventoryDTO>("Invalid team.");
            }

            if (!team.IsActive)
            {
                return new ErrorDataResult<ConsumableInventoryDTO>("This team is not active.");
            }

            if (string.IsNullOrEmpty(request.Name) || request.Quantity <= 0 || string.IsNullOrEmpty(request.Details))
            {
                return new ErrorDataResult<ConsumableInventoryDTO>("Invalid request.");
            }

            team.ConsumableInventory.Add(request.Adapt<ConsumableInventory>());
            await _commandRepository.UpdateAsync(team);
            var consumableInventory = team.ConsumableInventory.ToList().Last();
            var consumableInventoryDTO = consumableInventory.Adapt<ConsumableInventoryDTO>();
            consumableInventoryDTO.InventoryId = consumableInventory.Id.ToString();

            return new DataResult<ConsumableInventoryDTO>(true, consumableInventoryDTO);

        }
    }
}