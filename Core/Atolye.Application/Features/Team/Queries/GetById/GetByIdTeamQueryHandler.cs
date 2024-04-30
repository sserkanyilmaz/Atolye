using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Queries.GetById
{
	public record GetByIdTeamQueryRequest(string TeamId) : IRequest<IDataResult<TeamDTO>>;

    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQueryRequest, IDataResult<TeamDTO>>
	{
        IQueryRepository<Domain.Entities.Team> _teamQueryRepository;
        ICommandRepository<Domain.Entities.Team> _teamCommandRepository;
        public GetByIdTeamQueryHandler(IQueryRepository<Domain.Entities.Team> teamQueryRepository, ICommandRepository<Domain.Entities.Team> teamCommandRepository)
        {
            _teamQueryRepository = teamQueryRepository;
            _teamCommandRepository = teamCommandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(GetByIdTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var team = await _teamQueryRepository.Table.Include(t => t.Members)
                                                   .Include(t => t.Project)
                                                   .Include(t => t.Images)
                                                   .Include(t => t.ConsumableInventory)
                                                   .Include(t => t.Reports)
                                                   .Where(t => t.IsActive == true)
                                                   .FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.TeamId));

            var teamDTO = new TeamDTO() {
                TakımId = team.Id.ToString(),
                Name = team.Name,
                Members = team.Members?.Select(m => m.Adapt<PersonDTO>()).ToList() ?? new List<PersonDTO>(),
                Projects = team.Project.Adapt<ProjectDTO>() ?? new ProjectDTO(),
                Achievements = team.Achievements,
                History = team.History,
                Images = team.Images?.Select(img => img.Adapt<ImageDTO>()).ToList() ?? new List<ImageDTO>(),
                ConsumableInventory = team.ConsumableInventory?.Select(ci => ci.Adapt<ConsumableInventoryDTO>()).ToList() ?? new List<ConsumableInventoryDTO>(),
                Reports = team.Reports?.Select(r => r.Adapt<ReportDTO>()).ToList() ?? new List<ReportDTO>(),
            };
            return new DataResult<TeamDTO>(true, teamDTO);

        }
    }
}

