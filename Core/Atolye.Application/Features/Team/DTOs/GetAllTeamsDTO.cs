using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Team.DTOs
{
	public class GetAllTeamsDTO : IDTO
	{
        public string? TakımId { get; set; }
        public string? Name { get; set; }

        public ICollection<Person>? Members { get; set; }

        public ICollection<Project>? Projects { get; set; }

        public string? Achievements { get; set; }
        public string? History { get; set; }

        public ICollection<Image>? Images { get; set; }

        public ICollection<ConsumableInventory>? ConsumableInventory { get; set; }

        public ICollection<Report>? Reports { get; set; }
    }
}

