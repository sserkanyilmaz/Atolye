using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Commands.AddBaseInformation;

public record AddBaseInformationCommandRequest(
    string Content,
    string ContactInfo,
    string BaseId) : IRequest<IDataResult<BaseDto>>;

public class AddBaseInformationCommandHandler : IRequestHandler<AddBaseInformationCommandRequest, IDataResult<BaseDto>>
{
    ICommandRepository<Domain.Entities.Base>  _commandRepository;
    private IQueryRepository<Domain.Entities.Base> _queryRepository;
    public AddBaseInformationCommandHandler(IQueryRepository<Domain.Entities.Base> queryRepository, ICommandRepository<Domain.Entities.Base> commandRepository)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }
    public async Task<IDataResult<BaseDto>> Handle(AddBaseInformationCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
        if (string.IsNullOrEmpty(request.Content) || string.IsNullOrEmpty(request.ContactInfo) || string.IsNullOrEmpty(request.BaseId))
        {
            return new ErrorDataResult<BaseDto>("Request parameters must not be null or empty.");
        }

        if(!Guid.TryParse(request.BaseId, out var guidValue))
        {
            return new ErrorDataResult<BaseDto>("Provided BaseId is not a valid GUID.");
        }

        
        var Base = await _queryRepository.Table.Include(b => b.FixtureInformation)
           .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId ));
        if (Base == null)
        {
            return new ErrorDataResult<BaseDto>("Base doesn't exist with the provided BaseId. Please provide a valid BaseId.");
        }
        if (!Base.IsActive)
        {
            return new ErrorDataResult<BaseDto>("The base is not activated.");
        }
        Base.FixtureInformation = new FixtureInformation()
        {
            Content = request.Content,
            ContactInfo = request.ContactInfo,
            
        };
        _commandRepository.UpdateAsync(Base);
        return new SuccessDataResult<BaseDto>("başarılı ", Base.Adapt<BaseDto>());
    }
}
