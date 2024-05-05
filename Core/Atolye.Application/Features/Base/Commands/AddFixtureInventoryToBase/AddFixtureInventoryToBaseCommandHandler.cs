using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Commands.AddFixtureInventoryToBase;

public record AddFixtureInventoryToBaseCommandRequest(string BaseId,string Name, int Quantity, string Details)
    : IRequest<IDataResult<BaseDto>>;

public class AddFixtureInventoryToBaseCommandHandler : IRequestHandler<AddFixtureInventoryToBaseCommandRequest, IDataResult<BaseDto>>
{
    private ICommandRepository<Domain.Entities.Base> _commandRepository;

    private IQueryRepository<Domain.Entities.Base> _queryRepository;
    public AddFixtureInventoryToBaseCommandHandler(ICommandRepository<Domain.Entities.Base> commandRepository, IQueryRepository<Domain.Entities.Base> queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddFixtureInventoryToBaseCommandRequest request, CancellationToken cancellationToken)
    {
        var baseEntity = await _queryRepository.Table.Include(b => b.FixtureInventories)
            .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId));
       if (baseEntity == null)
       { 
           return new ErrorDataResult<BaseDto>("Base not found");
       }
       var fixtureInventory = new FixtureInventory
       {
           Name = request.Name, Quantity = request.Quantity, Details = request.Details
       };   

       baseEntity.FixtureInventories.Add(fixtureInventory);
       await _commandRepository.UpdateAsync(baseEntity);       

       var baseDTO = baseEntity.Adapt<BaseDto>();
       return new SuccessDataResult<BaseDto>(baseDTO);
    }
} 