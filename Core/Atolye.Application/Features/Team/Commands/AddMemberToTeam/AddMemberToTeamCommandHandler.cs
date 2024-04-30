using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.AddMemberToTeam
{
	public record AddMemberToTeamCommandRequest(string TeamId, string PersonId) : IRequest<IDataResult<TeamDTO>>;

    public class AddMemberToTeamCommandHandler : IRequestHandler<AddMemberToTeamCommandRequest, IDataResult<TeamDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        IQueryRepository<Person> _personQueryRepository;
        public AddMemberToTeamCommandHandler(ICommandRepository<Domain.Entities.Team> commandRepository, IQueryRepository<Domain.Entities.Team> queryRepository, IQueryRepository<Person> personQueryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(AddMemberToTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = await _queryRepository.Table.Include(t => t.Members).FirstOrDefaultAsync(u => u.Id == Guid.Parse(request.TeamId));
            var member = await _personQueryRepository.GetByIdAsync(request.PersonId);
            team.Members.Add(member);
            await _commandRepository.UpdateAsync(team);
            return new DataResult<TeamDTO>(true, team.Adapt<TeamDTO>());

        }
    }
}

