using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
public record AddBaseNewsToBaseCommandRequest(string BaseId, string NewsContent)
    : IRequest<IDataResult<BaseDto>>;

public class AddBaseNewsToBaseCommandHandler : IRequestHandler<AddBaseNewsToBaseCommandRequest, IDataResult<BaseDto>>
{
    private ICommandRepository<Base> _commandRepository;
    private IQueryRepository<Base> _queryRepository;

    public AddBaseNewsToBaseCommandHandler(ICommandRepository<Base> commandRepository, IQueryRepository<Base> queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddBaseNewsToBaseCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
        var baseEntity = await _queryRepository.Table.Include(b => b.BaseNews)
            .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId));
        
        
        if (string.IsNullOrEmpty(request.BaseId) || string.IsNullOrEmpty(request.NewsContent)) 
        {
            return new ErrorDataResult<BaseDto>("Request parameters cannot be null or empty");
        }

        if (baseEntity == null)
        {
            return new ErrorDataResult<BaseDto>("Base not found");
        }

        if (!baseEntity.IsActive)
        {
            return new ErrorDataResult<BaseDto>("Base is not active");
        }
        var baseNew = new BaseNew
        {
            News = request.NewsContent,
        };

        baseEntity.BaseNews.Add(baseNew);
        await _commandRepository.UpdateAsync(baseEntity);

        var baseDTO = baseEntity.Adapt<BaseDto>();
        return new SuccessDataResult<BaseDto>(baseDTO);
    }
}