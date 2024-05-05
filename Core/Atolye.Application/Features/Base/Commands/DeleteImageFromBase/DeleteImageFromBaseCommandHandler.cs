using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Commands.DeleteImageFromBase;
public record DeleteImageFromBaseCommandRequest (string ImageId , string BaseId) : IRequest<IDataResult<BaseDto>>;
public class DeleteImageFromBaseCommandHandler : IRequestHandler<DeleteImageFromBaseCommandRequest, IDataResult<BaseDto>>
{
    ICommandRepository<Domain.Entities.Base> _baseCommandRepository;
    IQueryRepository<Domain.Entities.Base> _baseQueryRepository;
    IQueryRepository<Image> _imageQueryRepository;
    ICommandRepository<Image> _imageCommandRepository;

    public DeleteImageFromBaseCommandHandler(IQueryRepository<Domain.Entities.Base> baseQueryRepository, ICommandRepository<Domain.Entities.Base> baseCommandRepository, ICommandRepository<Image> imageCommandRepository, IQueryRepository<Image> imageQueryRepository)
    {
        _baseQueryRepository = baseQueryRepository;
        _baseCommandRepository = baseCommandRepository;
        _imageCommandRepository = imageCommandRepository;
        _imageQueryRepository = imageQueryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(DeleteImageFromBaseCommandRequest request, CancellationToken cancellationToken)
    {
        var Base = await _baseQueryRepository.Table.Include(b => b.Images)
            .FirstOrDefaultAsync(b => b.Id == Guid.Parse(request.BaseId));
        var image = await _imageQueryRepository.GetByIdAsync(request.ImageId);
        await _imageCommandRepository.RemoveAsync(request.ImageId);
        await _imageCommandRepository.SaveAsync();
        return new DataResult<BaseDto>("Image deleted successfully from the base.",true, Base.Adapt<BaseDto>());

    }
}