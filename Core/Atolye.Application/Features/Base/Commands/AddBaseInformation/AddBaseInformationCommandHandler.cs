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
        var Base = await _queryRepository.Table.Include(b => b.FixtureInformation)
           .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId ));
        Base.FixtureInformation = new FixtureInformation()
        {
            Content = request.Content,
            ContactInfo = request.ContactInfo,
            
        };
        _commandRepository.UpdateAsync(Base);
        return new SuccessDataResult<BaseDto>("başarılı ", Base.Adapt<BaseDto>());
    }
}
