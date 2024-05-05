using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using MediatR;

namespace Atolye.Application.Features.Base.Commands.DeleteActivityLogFromBase;

public record DeleteActivityLogFromBaseCommandRequest(string BaseId, string ActivityLogId)
    : IRequest<IDataResult<BaseDto>>;
public class DeleteActivityLogFromBaseCommandHandler : IRequestHandler<DeleteActivityLogFromBaseCommandRequest , IDataResult<BaseDto>>
{
    private ICommandRepository<ActivityLog> _activityLogCommandRepository;
    private IQueryRepository<ActivityLog> _activityLogQueryRepository;
    private ICommandRepository<Domain.Entities.Base> _commandRepository;
    private IQueryRepository<Domain.Entities.Base> _queryRepository;

    public DeleteActivityLogFromBaseCommandHandler(ICommandRepository<ActivityLog> activityLogCommandRepository, IQueryRepository<ActivityLog> activityLogQueryRepository, ICommandRepository<Domain.Entities.Base> commandRepository, IQueryRepository<Domain.Entities.Base> queryRepository)
    {
        _activityLogCommandRepository = activityLogCommandRepository;
        _activityLogQueryRepository = activityLogQueryRepository;
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public Task<IDataResult<BaseDto>> Handle(DeleteActivityLogFromBaseCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception();
    }
}