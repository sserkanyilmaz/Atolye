using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.DeleteFixtureInventoryFromBase;

public record DeleteFixtureInventoryFromBaseCommandRequest(string BaseId, string FixtureInventoryId)
    : IRequest<IDataResult<BaseDto>>;
public class DeleteFixtureInventoryFromBaseCommandHandler : IRequestHandler<DeleteFixtureInventoryFromBaseCommandRequest, IDataResult<BaseDto>>
{
    private IQueryRepository<Domain.Entities.Base> _queryRepository;
    private IQueryRepository<Inventory> _fixtureQueryRepository;
    
    private ICommandRepository<Inventory> _fixtureCommandRepository;

    public DeleteFixtureInventoryFromBaseCommandHandler(IQueryRepository<Domain.Entities.Base> queryRepository, IQueryRepository<Inventory> fixtureQueryRepository, ICommandRepository<Inventory> fixtureCommandRepository)
    {
        _queryRepository = queryRepository;
        _fixtureQueryRepository = fixtureQueryRepository;
        _fixtureCommandRepository = fixtureCommandRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(DeleteFixtureInventoryFromBaseCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
        if (!Guid.TryParse(request.FixtureInventoryId, out _))
        {
            return new ErrorDataResult<BaseDto>("FixtureInventoryId is not a valid GUID.");
        }
        var fixtureInventory = await _fixtureQueryRepository.GetByIdAsync(request.FixtureInventoryId);
        if (fixtureInventory != null)
        {
            fixtureInventory.IsActive = false;
            await _fixtureCommandRepository.UpdateAsync(fixtureInventory);
            await _fixtureCommandRepository.SaveAsync();
        }
        Domain.Entities.Base BaseEntity = await _queryRepository.GetByIdAsync(request.BaseId);
        return new SuccessDataResult<BaseDto>(BaseEntity.Adapt<BaseDto>()); 
    }
}