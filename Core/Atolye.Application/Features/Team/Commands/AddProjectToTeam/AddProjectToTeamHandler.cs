using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.Add;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Team.Commands.AddProjectToTeam
{
    public record AddProjectToTeamRequest(string TeamId, string Name, string Description) : IRequest<IDataResult<ProjectDTO>>;
    public class AddProjectToTeamHandler : IRequestHandler<AddProjectToTeamRequest, IDataResult<ProjectDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        public AddProjectToTeamHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<IDataResult<ProjectDTO>> Handle(AddProjectToTeamRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.TeamId, out _))
            {
                return new ErrorDataResult<ProjectDTO>("TeamId is not a valid GUID.");
            }
            var team = await _queryRepository.GetByIdAsync(request.TeamId);
            
            if(string.IsNullOrEmpty(request.TeamId) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
            {
                return new ErrorDataResult<ProjectDTO>("Invalid request parameters");
            }

            if (team is null)
            {
                return new ErrorDataResult<ProjectDTO>("The team does not exist");
            }

            if (!team.IsActive)
            {
                return new ErrorDataResult<ProjectDTO>("The team is not active");
            }
            team.Project = request.Adapt<Project>();
            await _commandRepository.UpdateAsync(team);
            ProjectDTO projectDTO = team.Project.Adapt<ProjectDTO>();
            projectDTO.ProjectId = team.Project.Id.ToString();
            return new DataResult<ProjectDTO>(true, projectDTO);

        }
    }
}

