using System.Xml;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Base.Queryies.GetBase;

public record GetBaseQueryRequest() : IRequest<IDataResult<GetBaseDto>>;
public class GetBaseQueryHandler : IRequestHandler<GetBaseQueryRequest, IDataResult<GetBaseDto>>
{
    private readonly IQueryRepository<Domain.Entities.Base> _queryRepository;

    public GetBaseQueryHandler(IQueryRepository<Domain.Entities.Base> baseRepository)
    {
        _queryRepository = baseRepository;
    }

    public async Task<IDataResult<GetBaseDto>> Handle(GetBaseQueryRequest request, CancellationToken cancellationToken)
    {
        var Base = (await _queryRepository.GetAll()
                .Include(b => b.Teams)
                .ThenInclude(t => t.Members)
                .Include(b => b.Teams)
                .ThenInclude(t => t.Project)
                .Include(b => b.Teams)
                .ThenInclude(t => t.Images)
                .Include(b => b.Teams)
                .ThenInclude(t => t.ConsumableInventory)
                .Include(b => b.Teams)
                .ThenInclude(t => t.Reports)
                .Include(b => b.Images)
                .Include(b => b.FixtureInventories)
                .Include(b => b.CareerStuffs)
                .ThenInclude(b=>b.Images)
                .Include(b => b.CareerStuffs)
                .ThenInclude(b=>b.News)
                .Include(b => b.FixtureInformation)
                .Include(b => b.BaseNews)
                .Include(b => b.ActivityLogs)
                .Include(b => b.Contact)
                .ToListAsync())
            .Last();    
    if (Base == null)
        return new ErrorDataResult<GetBaseDto>(  "No base found with the given criteria");

    var getBaseDto = new GetBaseDto
    {
        Name = Base.Name,
        BaseId = Base.Id.ToString(),
        Teams = Base.Teams?.Select(t => 
            new TeamDTO()
            {
                TakımId = t.Id.ToString(),
                Name = t.Name,
                Members = t.Members?.Select(m => m.Adapt<PersonDTO>()).ToList() ?? new List<PersonDTO>(),
                Projects = t.Project?.Adapt<ProjectDTO>(),
                Images = t.Images?.Select(i => i.Adapt<ImageDTO>()).ToList() ?? new List<ImageDTO>(),
                ConsumableInventory =
                    t.ConsumableInventory?.Select(ci => ci.Adapt<ConsumableInventoryDTO>()).ToList() ??
                    new List<ConsumableInventoryDTO>(),
                Reports = t.Reports?.Select(r => r.Adapt<ReportDTO>()).ToList() ?? new List<ReportDTO>()
            }).ToList() ?? new List<TeamDTO>(),
        Images = Base.Images?.Select(i => i.Adapt<BaseImageDTO>()).ToList() ?? new List<BaseImageDTO>(),
        FixtureInventories = Base.FixtureInventories?.Select(fi => fi.Adapt<FixtureInventoryDTO>()).ToList() ?? new List<FixtureInventoryDTO>(),
        CareerStuffs = Base.CareerStuffs?.Select(cs => new CareerStuffDTO
        {
            Images = cs.Images?.Select(img => img.Adapt<BaseImageDTO>()).ToList() ?? new List<BaseImageDTO>(),
            News = cs.News?.Select(n => n.Adapt<BaseNewDTO>()).ToList() ?? new List<BaseNewDTO>()
        }).ToList() ?? new List<CareerStuffDTO>(),
        FixtureInformation = Base.FixtureInformation == null ? null : new FixtureInformationDTO
        {
            FixtureInformationId = Base.FixtureInformation.Id.ToString(),
            Content = Base.FixtureInformation.Content,
            ContactInfo = Base.FixtureInformation.ContactInfo 
        },
        FixtureInformationId = Base.FixtureInformationId,
        BaseNews = Base.BaseNews?.Select(bn => bn.Adapt<BaseNewDTO>()).ToList() ?? new List<BaseNewDTO>(),
        ActivityLogs = Base.ActivityLogs?.Select(al => al.Adapt<ActivityLogDTO>()).ToList() ?? new List<ActivityLogDTO>()
    };
    
    return new DataResult<GetBaseDto>( "Successful operation",true,getBaseDto);
    }
}