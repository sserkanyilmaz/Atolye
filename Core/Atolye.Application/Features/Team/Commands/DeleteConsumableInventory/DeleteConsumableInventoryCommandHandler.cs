﻿using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Features.Team.Commands.Delete;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.DeleteConsumableInventory
{
    public record DeleteConsumableInventoryCommandRequest(string TeamId,string InventoryId) : IRequest<IDataResult<TeamDTO>>;
    public class DeleteConsumableInventoryCommandHandler : IRequestHandler<DeleteConsumableInventoryCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        IQueryRepository<Domain.Entities.ConsumableInventory> _consumableInventoryqueryRepository;
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        ICommandRepository<Domain.Entities.ConsumableInventory> _consumableInventorycommandRepository;
        public DeleteConsumableInventoryCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository, IQueryRepository<Domain.Entities.ConsumableInventory> consumableInventoryqueryRepository, ICommandRepository<Domain.Entities.ConsumableInventory> consumableInventorycommandRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _consumableInventoryqueryRepository = consumableInventoryqueryRepository;
            _consumableInventorycommandRepository = consumableInventorycommandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteConsumableInventoryCommandRequest request, CancellationToken cancellationToken)
        {
                        
            if (!Guid.TryParse(request.TeamId, out _))
            {
                throw new ArgumentException("TeamId is not a valid guid string");
            }

            Guid inventoryIdGuid;
            if (!Guid.TryParse(request.InventoryId, out _))
            {
                throw new ArgumentException("InventoryId is not a valid guid string");
            }
            var inventory =await _consumableInventorycommandRepository.RemoveAsync(request.InventoryId);
            var team = await _queryRepository.Table.Include(t => t.ConsumableInventory).FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.TeamId));
            
            if (team == null || !team.IsActive)
            {
                return new ErrorDataResult<TeamDTO>("Team does not exist or is not active");
            }

            if (inventory == null || !inventory.IsActive)
            {
                return new ErrorDataResult<TeamDTO>("Inventory does not exist or is not active");
            }
            var teamDTO = team.Adapt<TeamDTO>();
            teamDTO.ConsumableInventory = team.ConsumableInventory.Where(ci=>ci.IsActive== true).Select(ci => ci.Adapt<ConsumableInventoryDTO>()).ToList() ?? new List<ConsumableInventoryDTO>();
            return new DataResult<TeamDTO>(true, teamDTO);

        }
    }
}

