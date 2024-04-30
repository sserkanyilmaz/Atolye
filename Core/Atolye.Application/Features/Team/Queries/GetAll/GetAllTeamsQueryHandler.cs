using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Features.Persons.Queries.GetAll;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Atolye.Application.Features.Team.Queries.GetAll
{
	public record GetAllTeamsQueryResponse(List<TeamDTO> TeamDTOs , int totalCount) : IRequest<IDataResult<TeamDTO>>,IDTO
	{
        public GetAllTeamsQueryResponse() : this(new List<TeamDTO>(), 0) { }
	};
    public record GetAllTeamsQueryRequest() : IRequest<IDataResult<GetAllTeamsQueryResponse>>;

    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQueryRequest, IDataResult<GetAllTeamsQueryResponse>>
    {

        IQueryRepository<Domain.Entities.Team> _queryRepository;
        public GetAllTeamsQueryHandler(IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IDataResult<GetAllTeamsQueryResponse>> Handle(GetAllTeamsQueryRequest request, CancellationToken cancellationToken)
        {
            var teams = await _queryRepository.Table.Include(t => t.Members)
                                                    .Include(t => t.Project)
                                                    .Include(t => t.Images)
                                                    .Include(t => t.ConsumableInventory)
                                                    .Include(t => t.Reports)
                                                    .Where(t=>t.IsActive == true)
                                                    .ToListAsync();

            var teamDTOs = teams.Select(team => new TeamDTO
            {
                TakımId = team.Id.ToString(),
                Name = team.Name,
                Members = team.Members?.Select(m => m.Adapt<PersonDTO>()).ToList() ?? new List<PersonDTO>(),
                Projects = team.Project.Adapt<ProjectDTO>() ?? new ProjectDTO(),
                Achievements = team.Achievements,
                History = team.History,
                Images = team.Images?.Select(img => img.Adapt<ImageDTO>()).ToList() ?? new List<ImageDTO>(),
                ConsumableInventory = team.ConsumableInventory?.Select(ci => ci.Adapt<ConsumableInventoryDTO>()).ToList() ?? new List<ConsumableInventoryDTO>(),
                Reports = team.Reports?.Select(r => r.Adapt<ReportDTO>()).ToList() ?? new List<ReportDTO>(),
            }).ToList();
            return new SuccessDataResult<GetAllTeamsQueryResponse>(
                "Veriler Listelendi.",
                new GetAllTeamsQueryResponse(teamDTOs, teamDTOs.Count()));
        }
    }
}

