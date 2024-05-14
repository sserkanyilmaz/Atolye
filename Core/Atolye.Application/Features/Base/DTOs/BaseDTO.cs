using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Base.DTOs;

public class BaseDto : IDTO
{
    public string? BaseId { get; set; }
    public string? Name { get; set; }
}