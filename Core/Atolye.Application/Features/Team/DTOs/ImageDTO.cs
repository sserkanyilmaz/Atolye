using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Team.DTOs
{
	public class ImageDTO : IDTO
	{
        public string? TeamId { get; set; }
        public string? ImageId { get; set; }
        public string? URL { get; set; }
    }
}

