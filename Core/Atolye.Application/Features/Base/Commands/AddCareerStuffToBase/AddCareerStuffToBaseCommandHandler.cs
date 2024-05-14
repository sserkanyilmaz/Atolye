using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record AddCareerStuffToBaseCommandRequest(string BaseId, List<string> NewsContents, List<string> ImageUrls)
    : IRequest<IDataResult<BaseDto>>;

public class AddCareerStuffToBaseCommandHandler : IRequestHandler<AddCareerStuffToBaseCommandRequest, IDataResult<BaseDto>>
{
    private ICommandRepository<Base> _commandRepository;
    private IQueryRepository<Base> _queryRepository;

    public AddCareerStuffToBaseCommandHandler(ICommandRepository<Base> commandRepository, IQueryRepository<Base> queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddCareerStuffToBaseCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
        var baseEntity = await _queryRepository.Table.Include(b => b.CareerStuffs)
            .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId));
        
        if (baseEntity == null || !baseEntity.IsActive)
        {
            return new ErrorDataResult<BaseDto>("Base not found or inactive");
        }

        if(request.NewsContents == null || request.NewsContents.Contains(null) || !request.NewsContents.Any()) 
        {
            return new ErrorDataResult<BaseDto>("NewsContents are not valid");
        }

        if(request.ImageUrls == null || request.ImageUrls.Contains(null) || !request.ImageUrls.Any()) 
        {
            return new ErrorDataResult<BaseDto>("ImageUrls are not valid");
        }
        var careerStuff = new CareerStuff();
        careerStuff.Images = new List<Image>();
        careerStuff.News = new List<BaseNew>();

        foreach (var newsContent in request.NewsContents)
        {
            careerStuff.News.Add(new BaseNew { News = newsContent });
        }

        foreach (var imageUrl in request.ImageUrls)
        {
            careerStuff.Images.Add(new Image { URL = imageUrl });
        }

        baseEntity.CareerStuffs.Add(careerStuff);
        await _commandRepository.UpdateAsync(baseEntity);

        var baseDTO = baseEntity.Adapt<BaseDto>();
        return new SuccessDataResult<BaseDto>(baseDTO);
    }
}