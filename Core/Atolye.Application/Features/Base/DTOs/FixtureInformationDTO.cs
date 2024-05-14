using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Base.DTOs
{
    public class FixtureInformationDTO :IDTO
    {
        public string? FixtureInformationId { get; set; }
        public string? Content { get; set; }
        public string? ContactInfo { get; set; }
    }
}