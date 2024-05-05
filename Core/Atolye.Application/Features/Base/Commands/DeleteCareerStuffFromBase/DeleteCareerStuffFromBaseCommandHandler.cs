using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record DeleteCareerStuffFromBaseCommandRequest(string BaseId, string CareerStuffId)
    : IRequest<IDataResult<BaseDto>>;

public class DeleteCareerStuffFromBaseCommandHandler : IRequestHandler<DeleteCareerStuffFromBaseCommandRequest, IDataResult<BaseDto>>
{
    private IQueryRepository<Base> _queryRepository;
    private ICommandRepository<CareerStuff> _careerStuffCommandRepository;

    public DeleteCareerStuffFromBaseCommandHandler(ICommandRepository<CareerStuff> careerStuffCommandRepository, IQueryRepository<Base> queryRepository)
    {
        _careerStuffCommandRepository = careerStuffCommandRepository;
        _queryRepository = queryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(DeleteCareerStuffFromBaseCommandRequest request, CancellationToken cancellationToken)
    {
        var baseEntity = await _queryRepository.Table.Include(b => b.CareerStuffs)
            .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId));
        if (baseEntity == null)
        {
            return new ErrorDataResult<BaseDto>("Base not found");
        }

        var careerStuff = baseEntity.CareerStuffs?.FirstOrDefault(cs => cs.Id == Guid.Parse(request.CareerStuffId));
        if (careerStuff == null)
        {
            return new ErrorDataResult<BaseDto>("CareerStuff not found");
        }

        careerStuff.IsActive = false;
        await _careerStuffCommandRepository.UpdateAsync(careerStuff);
        await _careerStuffCommandRepository.SaveAsync();

        var baseDTO = baseEntity.Adapt<BaseDto>();
        return new SuccessDataResult<BaseDto>(baseDTO);
    }
}