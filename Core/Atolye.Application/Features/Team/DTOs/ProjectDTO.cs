using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Team.DTOs
{
	public class ProjectDTO : IDTO
    {
        public string? TeamId { get; set; }
        public string? ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

