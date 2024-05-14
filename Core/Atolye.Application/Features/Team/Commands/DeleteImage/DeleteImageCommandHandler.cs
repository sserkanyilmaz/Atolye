using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.DeleteImage
{
    public record DeleteImageCommandRequest(string TeamId, string ImageId) : IRequest<IDataResult<TeamDTO>>;
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommandRequest, IDataResult<TeamDTO>>
    {
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        ICommandRepository<Domain.Entities.Image> _imageCommandRepository;
        public DeleteImageCommandHandler(IQueryRepository<Domain.Entities.Team> queryRepository,ICommandRepository<Domain.Entities.Image> imageCommandRepository)
        {
            _queryRepository = queryRepository;
            _imageCommandRepository = imageCommandRepository;
        }

        public async Task<IDataResult<TeamDTO>> Handle(DeleteImageCommandRequest request, CancellationToken cancellationToken)
        {
            
            var image = await _imageCommandRepository.RemoveAsync(request.ImageId);
            var team = await _queryRepository.Table.Include(t => t.Images).FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.TeamId));
            var teamDTO = team.Adapt<TeamDTO>();
            teamDTO.Images = team.Images.Where(i => i.IsActive == true).Select(i => i.Adapt<ImageDTO>()).ToList() ?? new List<ImageDTO>();
            return new DataResult<TeamDTO>(true, teamDTO);

        }
    }
}

