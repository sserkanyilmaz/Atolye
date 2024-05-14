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
    private readonly IQueryRepository<Person> _personRepository;

    public AddActivityLogToBaseCommandHandler(ICommandRepository<ActivityLog> commandRepository, IQueryRepository<Domain.Entities.Base> baseRepository,IQueryRepository<Person> personRepository, ICommandRepository<Domain.Entities.Base> baseCommandRepository)
    {
        _commandRepository = commandRepository;
        _baseRepository = baseRepository;
        _baseCommandRepository = baseCommandRepository;
        _personRepository = personRepository;
    }

    public async Task<IDataResult<BaseDto>> Handle(AddActivityLogToBaseCommandRequest request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.PersonId, out _))
        {
            return new ErrorDataResult<BaseDto>("TeamId is not a valid GUID.");
        }
        if (!Guid.TryParse(request.BaseId, out _))
        {
            return new ErrorDataResult<BaseDto>("BaseId is not a valid GUID.");
        }
            if(string.IsNullOrEmpty(request.PersonId))
            {
                return new ErrorDataResult<BaseDto>("PersonId is required.");
            }
            if(string.IsNullOrEmpty(request.BaseId)) 
            {
                return new ErrorDataResult<BaseDto>("BaseId is required.");
            }
            if(request.TimeIn == DateTime.MinValue)
            {
                return new ErrorDataResult<BaseDto>("TimeIn is required.");
            }
            if(request.TimeOut == DateTime.MinValue)
            {
                return new ErrorDataResult<BaseDto>("TimeOut is required.");
            }
            
            var person = await _personRepository.GetByIdAsync(request.PersonId);
            if (person == null)
            {
                return new ErrorDataResult<BaseDto>("The person with the given id does not exist.");
            }
            if (!person.IsActive)
            {
                return new ErrorDataResult<BaseDto>("The person with the given id is not active.");
            }
            var baseEntity1 = await _baseRepository.GetByIdAsync(request.BaseId);

            if (baseEntity1 == null)
            {
                return new ErrorDataResult<BaseDto>("The base with the given id does not exist.");
            }

            if (!baseEntity1.IsActive)
            {
                return new ErrorDataResult<BaseDto>("The base with the given id is not active.");
            }
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