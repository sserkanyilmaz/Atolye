using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Base.DTOs;
using System.Linq;

namespace Atolye.Application.Features.Base.Commands.AddActivityLogToBase;

public class AddActivityLogToBaseCommandRequest : IRequest<IDataResult<BaseDto>>
{
    public string PersonId { get; set; }
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public string BaseId { get; set; }
}

public class AddActivityLogToBaseCommandHandler : IRequestHandler<AddActivityLogToBaseCommandRequest, IDataResult<BaseDto>>
{
    private readonly ICommandRepository<ActivityLog> _commandRepository;
    private readonly IQueryRepository<Domain.Entities.Base> _baseRepository;
    private readonly ICommandRepository<Domain.Entities.Base> _baseCommandRepository;

    public AddActivityLogToBaseCommandHandler(ICommandRepository<ActivityLog> commandRepository, IQueryRepository<Domain.Entities.Base> baseRepository, ICommandRepository<Domain.Entities.Base> baseCommandRepository)
    {
        _commandRepository = commandRepository;
        _baseRepository = baseRepository;
        _baseCommandRepository = baseCommandRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddActivityLogToBaseCommandRequest request, CancellationToken cancellationToken)
    {
            var activityLog = request.Adapt<ActivityLog>();
            await _commandRepository.AddAsync(activityLog);
            
            var baseEntity = await _baseRepository.GetByIdAsync(request.BaseId);

            if (baseEntity != null)
            {
                baseEntity.ActivityLogs ??= new List<ActivityLog>();
                baseEntity.ActivityLogs.Add(activityLog);
                await _baseCommandRepository.UpdateAsync(baseEntity);
            }


            var resultDto = baseEntity.Adapt<BaseDto>();
            return new SuccessDataResult<BaseDto>( "Activity added successfully",resultDto);
    }
}