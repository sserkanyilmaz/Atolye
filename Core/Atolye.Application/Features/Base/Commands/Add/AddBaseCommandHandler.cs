using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.Add
{
	public record AddBaseCommandRequest(string Name) : IRequest<IDataResult<BaseDto>>;
    public class AddBaseCommandHandler : IRequestHandler<AddBaseCommandRequest, IDataResult<BaseDto>>
	{
        ICommandRepository<Domain.Entities.Base> _commandRepository;
        public AddBaseCommandHandler(ICommandRepository<Domain.Entities.Base> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<IDataResult<BaseDto>> Handle(AddBaseCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(request.Adapt<Domain.Entities.Base>());
            await _commandRepository.SaveAsync();
            return new DataResult<BaseDto>(true, request.Adapt<BaseDto>());
        }
    }

}

