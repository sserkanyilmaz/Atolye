using Atolye.Application.Features.Team.DTOs;

namespace Atolye.Application.Features.Base.DTOs;

public class CareerStuffDTO
{
    public ICollection<BaseNewDTO>? News { get; set; }
    public ICollection<BaseImageDTO>? Images { get; set; }
}