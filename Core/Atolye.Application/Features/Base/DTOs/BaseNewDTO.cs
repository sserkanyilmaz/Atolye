using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Base.DTOs
{
    public class BaseNewDTO : IDTO
    {
        public string? BaseNewId { get; set; }
        public string? News { get; set; }
    }
}