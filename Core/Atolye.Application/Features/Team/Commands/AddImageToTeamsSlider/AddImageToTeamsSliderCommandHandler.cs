using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Team.Commands.Add;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Atolye.Application.Features.Team.Commands.AddImageToTeamsSlider
{
    public record AddImageToTeamsSliderCommandRequest(string TeamId,string URL) : IRequest<IDataResult<ImageDTO>>;
    public class AddImageToTeamsSliderCommandHandler : IRequestHandler<AddImageToTeamsSliderCommandRequest, IDataResult<ImageDTO>>
    {
        ICommandRepository<Domain.Entities.Team> _commandRepository;
        IQueryRepository<Domain.Entities.Team> _queryRepository;
        public AddImageToTeamsSliderCommandHandler(IQueryRepository<Domain.Entities.Team> queryRepository, ICommandRepository<Domain.Entities.Team> commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<IDataResult<ImageDTO>> Handle(AddImageToTeamsSliderCommandRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.TeamId, out _))
            {
                return new ErrorDataResult<ImageDTO>("TeamId is not a valid GUID.");
            }
            var team = await _queryRepository.Table.Include(t => t.Images).FirstOrDefaultAsync(u => u.Id == Guid.Parse(request.TeamId));
            
            if (team == null)
            {
                return new ErrorDataResult<ImageDTO>("Team doesn't exist");
            }
            if (!team.IsActive)
            {
                return new ErrorDataResult<ImageDTO>("Team is not active");
            }

            if (string.IsNullOrWhiteSpace(request.TeamId) || string.IsNullOrWhiteSpace(request.URL))
            {
                return new ErrorDataResult<ImageDTO>("Invalid request! TeamId and URL must not be empty");
            }
            team.Images?.Add(request.Adapt<Image>());
            await _commandRepository.UpdateAsync(team);
            var image = team.Images.ToList().Last();
            var imageDTO = image.Adapt<ImageDTO>();
            imageDTO.ImageId = image.Id.ToString();

            return new DataResult<ImageDTO>(true, imageDTO);
        }
    }
}

