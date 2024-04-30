using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Team.DTOs
{
	public class UpdateTeamDTO : IDTO
	{

        public string? TakımId { get; set; }
        public string? Name { get; set; }

        public string? Achievements { get; set; }
        public string? History { get; set; }
    }
}

