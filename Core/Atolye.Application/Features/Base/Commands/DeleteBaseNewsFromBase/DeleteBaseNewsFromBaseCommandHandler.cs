using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

public record DeleteBaseNewsFromBaseCommandRequest(string BaseId, string BaseNewsId)
    : IRequest<IDataResult<BaseDto>>;

public class DeleteBaseNewsFromBaseCommandHandler : IRequestHandler<DeleteBaseNewsFromBaseCommandRequest, IDataResult<BaseDto>>
{
    private IQueryRepository<Base> _queryRepository;
    private ICommandRepository<BaseNew> _baseNewCommandRepository;
    private IQueryRepository<BaseNew> _baseNewQueryRepository;

    public DeleteBaseNewsFromBaseCommandHandler(IQueryRepository<Base> queryRepository, ICommandRepository<BaseNew> baseNewCommandRepository, IQueryRepository<BaseNew> baseNewQueryRepository)
    {
        _queryRepository = queryRepository;
        _baseNewCommandRepository = baseNewCommandRepository;
        _baseNewQueryRepository = baseNewQueryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(DeleteBaseNewsFromBaseCommandRequest request, CancellationToken cancellationToken)
    {
        var baseNew = await _baseNewQueryRepository.GetByIdAsync(request.BaseNewsId);
        if (baseNew != null)
        {
            baseNew.IsActive = false;
            await _baseNewCommandRepository.UpdateAsync(baseNew);
            await _baseNewCommandRepository.SaveAsync();
        }

        var baseEntity = await _queryRepository.GetByIdAsync(request.BaseId);
        return new SuccessDataResult<BaseDto>(baseEntity.Adapt<BaseDto>());
    }
}