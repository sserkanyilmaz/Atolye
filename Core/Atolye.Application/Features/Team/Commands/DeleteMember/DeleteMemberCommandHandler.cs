using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.DeleteImage;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Team.Commands.DeleteMember
{
    public record DeleteMemberCommandRequest(string TeamId, string MemberId) : IRequest<IDataResult<TeamDTO>>;
    public class DeleteMemberCommandHandler: IRequestHandler<DeleteMemberCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _teamQueryRepository;
        ICommandRepository<Domain.Entities.Team> _teamCommandRepository;
        ICommandRepository<Person> _memberCommandRepository;
        IQueryRepository<Person> _memberQueryRepository;
        public DeleteMemberCommandHandler(ICommandRepository<Person> memberCommandRepository, IQueryRepository<Domain.Entities.Team> teamQueryRepository, IQueryRepository<Person> memberQueryRepository, ICommandRepository<Domain.Entities.Team> teamCommandRepository)
        {
            _memberCommandRepository = memberCommandRepository;
            _teamQueryRepository = teamQueryRepository;
            _memberQueryRepository = memberQueryRepository;
            _teamCommandRepository = teamCommandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteMemberCommandRequest request, CancellationToken cancellationToken)
        {
            var member = await _memberQueryRepository.GetByIdAsync(request.MemberId);
            member.Team = null;
            member.TeamId = null;
            await _memberCommandRepository.UpdateAsync(member);
            var team = await _teamQueryRepository.GetByIdAsync(request.TeamId);
            var teamDTO = team.Adapt<TeamDTO>();
            return new DataResult<TeamDTO>(true, teamDTO);

        }
    }
}

