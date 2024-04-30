using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.DeleteMember;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Team.Commands.DeleteProject
{
    public record DeleteProjectCommandRequest(string TeamId, string ProjectId) : IRequest<IDataResult<TeamDTO>>;
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _teamQueryRepository;
        ICommandRepository<Domain.Entities.Team> _teamCommandRepository;
        ICommandRepository<Project> _projectCommandRepository;
        IQueryRepository<Project> _projectQueryRepository;
        public DeleteProjectCommandHandler(IQueryRepository<Domain.Entities.Team> teamQueryRepository, ICommandRepository<Domain.Entities.Team> teamCommandRepository, ICommandRepository<Project> projectCommandRepository, IQueryRepository<Project> projectQueryRepository)
        {
            _teamQueryRepository = teamQueryRepository;
            _teamCommandRepository = teamCommandRepository;
            _projectCommandRepository = projectCommandRepository;
            _projectQueryRepository = projectQueryRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectQueryRepository.GetByIdAsync(request.ProjectId);
            project.Team = null;
            project.TeamId = null;
            await _projectCommandRepository.UpdateAsync(project);
            var team = await _teamQueryRepository.GetByIdAsync(request.TeamId);
            var teamDTO = team.Adapt<TeamDTO>();
            return new DataResult<TeamDTO>(true, teamDTO);

        }
    }
}

