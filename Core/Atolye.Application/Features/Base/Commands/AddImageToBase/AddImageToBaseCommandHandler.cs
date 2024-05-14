using System.Net.Mime;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Commands.AddImageToBase;

public record AddImageToBaseCommandRequest(string Url, string BaseId) : IRequest<IDataResult<BaseDto>>;
public class AddImageToBaseCommandHandler  : IRequestHandler<AddImageToBaseCommandRequest,IDataResult<BaseDto>>
{
    private ICommandRepository<Domain.Entities.Base> _commandRepository;
    private IQueryRepository<Domain.Entities.Base> _queryRepository;
    private IQueryRepository<Image> _imageQueryRepository;
    private ICommandRepository<Image> _imageCommandRepository;
    public AddImageToBaseCommandHandler(IQueryRepository<Domain.Entities.Base> queryRepository, ICommandRepository<Domain.Entities.Base> commandRepository, ICommandRepository<Image> imageCommandRepository, IQueryRepository<Image> imageQueryRepository)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _imageCommandRepository = imageCommandRepository;
        _imageQueryRepository = imageQueryRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddImageToBaseCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
        var Base =await  _queryRepository.Table.Include(i=>i.Images).FirstOrDefaultAsync(b=>b.Id == Guid.Parse(request.BaseId));
                
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.Url) || string.IsNullOrEmpty(request.BaseId))
        {
            throw new ArgumentException("Url or BaseId should not be null or empty.");
        }


        if (Base == null)
        {
            return new DataResult<BaseDto>("Base not found.", false, null); 
        }

         
        if (!Base.IsActive)
        {
            return new DataResult<BaseDto>("Base is not active.", false, null);
        }

        Base.Images.Add(new Image() { URL = request.Url });
        Base.Images.Add(new Image(){URL= request.Url}); 
        await _commandRepository.UpdateAsync(Base);
        return new DataResult<BaseDto>("Image successfully added to base.", true, Base.Adapt<BaseDto>());
    }
}