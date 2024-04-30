using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Team.DTOs
{
	public class TeamDTO : IDTO
	{

        public string? TakımId { get; set; }
        public string? Name { get; set; }

        public ICollection<PersonDTO>? Members { get; set; }

        public ProjectDTO? Projects { get; set; }

        public string? Achievements { get; set; }
        public string? History { get; set; }

        public ICollection<ImageDTO>? Images { get; set; }

        public ICollection<ConsumableInventoryDTO>? ConsumableInventory { get; set; }

        public ICollection<ReportDTO>? Reports { get; set; }
    }
}

